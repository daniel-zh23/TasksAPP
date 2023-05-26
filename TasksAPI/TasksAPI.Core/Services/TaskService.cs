using Microsoft.EntityFrameworkCore;
using TasksAPI.Core.Contracts;
using TasksAPI.Core.Models.Input;
using TasksAPI.Core.Models.View;
using TasksAPI.Database.Data.Common;
using Task = TasksAPI.Database.Data.Models.Task;

namespace TasksAPI.Core.Services;

public class TaskService : ITaskService
{
    private IRepository _repo;

    public TaskService(IRepository repo)
    {
        _repo = repo;
    }
    public async Task<List<TaskShortViewModel>> GetAll()
    {
        return await _repo.AllReadonly<Task>()
            .Where(t => t.IsActive)
            .Select(t => new TaskShortViewModel()
            {
                Id = t.Id,
                Title = t.Title,
                UsersCount = t.WorkingUsers.Count(),
                Date = t.DateOpened.ToString("dd/MM/yyyy")
            })
            .ToListAsync();
    }

    public async Task<int> Add(TaskInputModel model, string creatorId)
    {
        var entity = new Task()
        {
            Title = model.Title,
            Description = model.Description,
            CreatorId = creatorId,
            DateOpened = DateTime.UtcNow
        };

        try
        {
            await _repo.AddAsync(entity);
            await _repo.SaveChangesAsync();
        }
        catch (Exception)
        {
            return -1;
        }

        return entity.Id;
    }

    public async Task<bool> CheckIdExistence(int id)
    {
        var item = await _repo.AllReadonly<Task>()
            .Select(u => u.Id)
            .FirstOrDefaultAsync(uId => uId == id);
        return item != 0;
    }

    public async Task<int> Delete(int id, string userId)
    {
        var task = await _repo.GetByIdAsync<Task>(id);
        task.IsActive = false;
        if (userId != task.CreatorId)
        {
            return -1;
        }
        try
        {
            await _repo.SaveChangesAsync();
        }
        catch (Exception)
        {
            return -1;
        }

        return task.Id;
    }
}