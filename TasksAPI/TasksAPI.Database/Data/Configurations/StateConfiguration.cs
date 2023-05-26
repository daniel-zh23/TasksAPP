using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TasksAPI.Database.Data.Models;

namespace TasksAPI.Database.Data.Configurations;

public class StateConfiguration : IEntityTypeConfiguration<State>
{
    public void Configure(EntityTypeBuilder<State> builder)
    {
        builder.HasData(GetData());
    }

    private IEnumerable<State> GetData()
    {
        return new List<State>()
        {
            new ()
            {
                Id = 1,
                Name = "Assigned"
            },
            new ()
            {
                Id = 2,
                Name = "In Progress"
            },
            new ()
            {
                Id = 3,
                Name = "Finished"
            },
        };
    }
}