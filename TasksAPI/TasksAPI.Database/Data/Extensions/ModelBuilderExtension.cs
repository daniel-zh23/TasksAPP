using Microsoft.EntityFrameworkCore;
using TasksAPI.Database.Data.Configurations;

namespace TasksAPI.Database.Data.Extensions;

public static class ModelBuilderExtension
{
    public static void ApplyMockData(this ModelBuilder builder)
    {
        builder.ApplyConfiguration(new StateConfiguration());
    }
}