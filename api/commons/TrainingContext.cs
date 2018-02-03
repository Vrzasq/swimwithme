using Microsoft.EntityFrameworkCore;
using api.Models;
using api.tools;

namespace api.commons
{
    public class TrainingContext : DbContext
    {
        public TrainingContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<TrainingTask> TrainingTasks { get; set; }
    }
}