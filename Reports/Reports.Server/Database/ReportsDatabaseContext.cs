using Microsoft.EntityFrameworkCore;
using Reports.DAL.Entities;

namespace Reports.Server.Database
{
    public class ReportsDatabaseContext : DbContext
    {
        public ReportsDatabaseContext(DbContextOptions<ReportsDatabaseContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<TaskModel> Tasks { get; set; }
        public DbSet<ReportModel> Reports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("Employees");
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TaskModel>().ToTable("Tasks");
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ReportModel>().ToTable("Report");
            base.OnModelCreating(modelBuilder);
        }
    }
}