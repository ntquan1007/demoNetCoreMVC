using DemoNetCore.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoNetCore.Data
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Staff> Staffs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Project>();
            modelBuilder.Entity<Staff>();
            modelBuilder.Entity<Participant>().HasOne(c => c.Project).WithMany(t => t.Participants).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
