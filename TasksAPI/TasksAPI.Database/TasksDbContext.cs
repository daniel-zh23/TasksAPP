using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TasksAPI.Database.Data.Extensions;
using TasksAPI.Database.Data.Models;
using Task = TasksAPI.Database.Data.Models.Task;

namespace TasksAPI.Database;

public class TasksDbContext : IdentityDbContext
{
    public TasksDbContext(DbContextOptions<TasksDbContext> options)
    : base(options)
    {
    }

    public DbSet<Task> Tasks { get; set; }
    public DbSet<State> State { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyMockData();
        
        builder.Entity<UserTask>()
            .HasKey(e => new { e.UserId, e.TaskId });
        
        base.OnModelCreating(builder);
    }
}