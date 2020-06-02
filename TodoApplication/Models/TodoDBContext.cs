using Microsoft.EntityFrameworkCore;

namespace TodoApplication.Models
{
    public class TodoDBContext : DbContext
    {
        public TodoDBContext(DbContextOptions opts) : base(opts)
        {
        }

        public DbSet<Task> Tasks { get; set; }
          public DbSet<Status> Statuses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}
