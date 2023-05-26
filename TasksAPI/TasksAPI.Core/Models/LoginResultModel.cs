namespace TasksAPI.Core.Models;

public class LoginResultModel
{
    public string Email { get; set; } = null!;

    public string Token { get; set; } = null!;
}