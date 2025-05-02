using AdvancedHRMS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace AdvancedHRMS.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<Payrolls> Payrolls { get; set; } = null!;

        public DbSet<Attendance> Attendances { get; set; }


        public object PayrollPeriods { get; internal set; }
        public object PayrollRecords { get; internal set; }

       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Department-Employee relationship (One-to-Many)
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId)
                .OnDelete(DeleteBehavior.SetNull);

            // Department-Manager relationship (One-to-One)
            modelBuilder.Entity<Department>()
                .HasOne(d => d.Manager)
                .WithOne()
                .HasForeignKey<Department>(d => d.ManagerId)
                .OnDelete(DeleteBehavior.SetNull);

            // Employee-Payroll relationship (One-to-Many)
            modelBuilder.Entity<Payrolls>()
                .HasOne(p => p.Employee)
                .WithMany(e => e.Payrolls)
                .HasForeignKey(p => p.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            // Employee-Attendance relationship (One-to-Many)
            modelBuilder.Entity<Attendance>()
                .HasOne(a => a.Employee)
                .WithMany(e => e.Attendances)
                .HasForeignKey(a => a.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            // Employee-LeaveRequest relationship (One-to-Many)
            modelBuilder.Entity<LeaveRequest>()
                .HasOne(lr => lr.Employee)
                .WithMany(e => e.LeaveRequests)
                .HasForeignKey(lr => lr.EmployeeId)
                .OnDelete(DeleteBehavior.SetNull);

            // LeaveRequest-ProcessedBy relationship (Many-to-One)
            modelBuilder.Entity<LeaveRequest>()
                .HasOne(lr => lr.ProcessedBy)
                .WithMany()
                .HasForeignKey(lr => lr.ProcessedById)
                .OnDelete(DeleteBehavior.Restrict);

            // Employee-User relationship (One-to-One)
            modelBuilder.Entity<User>()
                .HasOne(u => u.Employee)
                .WithOne(e => e.User)
                .HasForeignKey<User>(u => u.EmployeeId)
                .OnDelete(DeleteBehavior.SetNull);

            // Add indexes for performance
            modelBuilder.Entity<Employee>()
                .HasIndex(e => e.Email)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }

    }
}
