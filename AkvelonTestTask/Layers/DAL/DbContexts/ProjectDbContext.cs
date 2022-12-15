using AkvelonTestTask.Models;
using Microsoft.EntityFrameworkCore;

namespace AkvelonTestTask.Layers.DAL.DbContexts
{
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options)
            : base(options)
        {
        }

        public DbSet<ProjectEntity> ProjectEntities { get; set; }

        public DbSet<TaskEntity> TaskEntities { get; set; }
    }
}