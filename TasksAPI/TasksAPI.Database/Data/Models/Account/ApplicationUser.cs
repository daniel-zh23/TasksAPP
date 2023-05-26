using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace TasksAPI.Database.Data.Models.Account;
public class ApplicationUser : IdentityUser
{
    [Required]
    public string FirstName { get; set; } = null!;

    [Required]
    public string LastName { get; set; } = null!;

    public IEnumerable<Task> CreatedTasks { get; set; } = new List<Task>();

    public IEnumerable<UserTask> ActiveTasks { get; set; } = new List<UserTask>();

}