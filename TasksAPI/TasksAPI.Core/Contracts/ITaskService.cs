using TasksAPI.Core.Models.Input;
using TasksAPI.Core.Models.View;

namespace TasksAPI.Core.Contracts;

public interface ITaskService
{
    public Task<List<TaskShortViewModel>> GetAll();

    public Task<int> Add(TaskInputModel model, string creatorId);

    public Task<bool> CheckIdExistence(int id);

    public Task<int> Delete(int id, string userId);
}