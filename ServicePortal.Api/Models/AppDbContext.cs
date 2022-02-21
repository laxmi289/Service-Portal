using Microsoft.EntityFrameworkCore;
using ServicePortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicePortal.Api.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options)
        {
        }

        public DbSet<UserData> UserData { get; set; }
        public DbSet<Department> Department { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed Departments Table
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 1, DepartmentName = "IT" });
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 2, DepartmentName = "HR" });
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 3, DepartmentName = "Payroll" });
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 4, DepartmentName = "Admin" });

            // Seed Employee Table
            modelBuilder.Entity<UserData>().HasData(new UserData
            {
                UserId = 1,
                FirstName = "John",
                LastName = "Hastings",
                Email = "john@test.com",
                DOB = new DateTime(1980, 10, 5),
                Gender = "Male",
                Address = "Texas",
                Phone = "9756431245",
                DepartmentId = 1
            });

            modelBuilder.Entity<UserData>().HasData(new UserData
            {
                UserId = 2,
                FirstName = "Sam",
                LastName = "Galloway",
                Email = "Sam@test.com",
                DOB = new DateTime(1981, 12, 22),
                Gender = "Male",
                Address = "Boston",
                Phone = "9756431245",
                DepartmentId = 2
            });

            modelBuilder.Entity<UserData>().HasData(new UserData
            {
                UserId = 3,
                FirstName = "Mary",
                LastName = "Smith",
                Email = "mary@test.com",
                DOB = new DateTime(1979, 11, 11),
                Gender = "Female",
                Address = "Vegas",
                Phone = "5656431245",
                DepartmentId = 3
            });

            modelBuilder.Entity<UserData>().HasData(new UserData
            {
                UserId = 4,
                FirstName = "Sara",
                LastName = "Longway",
                Email = "sara@test.com",
                DOB = new DateTime(1982, 9, 23),
                Gender = "Female",
                Address = "Vegas",
                Phone = "5656431245",
                DepartmentId = 4
            });
        }
    }
}
