using System.ComponentModel.DataAnnotations;

namespace TasksAPI.Core.Models.Input;

public class TaskInputModel
{
    [Required]
    public string Title { get; set; } = null!;
    [Required]
    public string Description { get; set; } = null!;
}