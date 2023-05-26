

using TasksAPI.Core.Models;
using TasksAPI.Database.Data.Models.Account;

namespace TasksAPI.Core.Contracts;

public interface ITokenService
{
    LoginResultModel LoginUser(ApplicationUser user);
}