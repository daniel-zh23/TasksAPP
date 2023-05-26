using System.ComponentModel.DataAnnotations.Schema;
using TasksAPI.Database.Data.Models.Account;

namespace TasksAPI.Database.Data.Models;

public class UserTask
{
    [ForeignKey(nameof(User))]
    public string UserId { get; set; } = null!;

    [ForeignKey(nameof(Task))]
    public int TaskId { get; set; }

    public ApplicationUser User { get; set; } = null!;

    public Task Task { get; set; } = null!;
}