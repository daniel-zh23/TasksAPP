namespace TasksAPI.Core.Contracts;

public interface IUserService<T>
{
    public Task<bool> CheckIdExistence(T id);
}