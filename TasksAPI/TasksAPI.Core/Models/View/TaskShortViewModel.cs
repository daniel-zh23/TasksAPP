namespace TasksAPI.Core.Models.View;

public class TaskShortViewModel
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public int UsersCount { get; set; }
    public string Date { get; set; } = null!;
}