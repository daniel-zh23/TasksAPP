using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TasksAPI.Database.Data.Models.Account;

namespace TasksAPI.Database.Data.Models;

public class Task
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Title { get; set; } = null!;

    [Required]
    public string Description { get; set; } = null!;

    [Required]
    public DateTime DateOpened { get; set; }

    [ForeignKey(nameof(Creator))]
    public string CreatorId { get; set; } = null!;

    [ForeignKey(nameof(State))]
    public int StateId { get; set; }

    public bool IsActive { get; set; } = true;


    public State State { get; set; } = null!;
    public IEnumerable<UserTask> WorkingUsers { get; set; } = new List<UserTask>();
    public ApplicationUser Creator { get; set; } = null!;
}