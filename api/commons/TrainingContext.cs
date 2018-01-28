using Microsoft.EntityFrameworkCore;
using api.Models;

namespace api.commons
{
    public class TrainingContext : DbContext
    {
        public TrainingContext(DbContextOptions<TrainingContext> options)
            : base(options)
        {
        }

        public DbSet<TrainingTask> TrainingTasks { get; set; }
    }
}