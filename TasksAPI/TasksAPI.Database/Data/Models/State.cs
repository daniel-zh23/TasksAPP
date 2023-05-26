using System.ComponentModel.DataAnnotations;

namespace TasksAPI.Database.Data.Models;

public class State
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = null!;

    public IEnumerable<Task> Tasks { get; set; } = new List<Task>();
}