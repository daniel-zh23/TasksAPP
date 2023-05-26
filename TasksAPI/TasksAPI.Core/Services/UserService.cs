using Microsoft.EntityFrameworkCore;
using TasksAPI.Core.Contracts;
using TasksAPI.Database.Data.Common;
using TasksAPI.Database.Data.Models.Account;

namespace TasksAPI.Core.Services;

public class UserService : IUserService<string>
{
    private IRepository _repo;

    public UserService(IRepository repo)
    {
        _repo = repo;
    }
    
    public async Task<bool> CheckIdExistence(string id)
    {
        var item = await _repo.AllReadonly<ApplicationUser>()
            .Select(u => u.Id)
            .FirstOrDefaultAsync(uId => uId == id);
        return item != null;
    }
}