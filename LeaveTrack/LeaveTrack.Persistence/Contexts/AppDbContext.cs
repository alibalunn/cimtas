using LeaveTrack.Domain.Entities;
using LeaveTrack.Persistence.Seeds;
using Microsoft.EntityFrameworkCore;

namespace LeaveTrack.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Leave>()
                .HasOne(l => l.Employee)
                .WithMany(e => e.Leaves)
                .HasForeignKey(l => l.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Leave>()
                .HasOne(l => l.CreatedByUser)
                .WithMany()
                .HasForeignKey(l => l.CreatedByUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.ApplyAllSeeds();

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Leave> Leaves { get; set; }
        public DbSet<LeaveSettings> LeaveSettings { get; set; }
        public DbSet<LeaveType> LeaveTypes { get; set; }
    }
}
