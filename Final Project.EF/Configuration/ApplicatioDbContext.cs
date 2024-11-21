using Final_Project.Core.Models;
using FinalProject.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project.EF.Configuration
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Event> Events { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<College> Colleges { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Course> Courses{ get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Quality> Qualities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<College>()
                .HasMany(c => c.Departments)
                .WithOne(d => d.College);

            modelBuilder.Entity<College>()
                .HasMany(c => c.Events)
                .WithOne(d => d.College);

           
            modelBuilder.Entity<College>()
                .HasMany(c => c.News)
                .WithOne(d => d.College);


            modelBuilder.Entity<Department>()
                .HasMany(d => d.Employees)
                .WithOne(e => e.Department)
                //.HasForeignKey(e=> e.DepartmentId)
                .OnDelete(DeleteBehavior.NoAction);



            modelBuilder.Entity<Department>()
                .HasMany(d => d.Courses)
                .WithOne(e => e.Department);

            modelBuilder.Entity<Unit>()
                .HasMany(u => u.Employees)
                .WithOne(e => e.Unit);
                //.HasForeignKey(e=> e.EmployeeId);

            modelBuilder.Entity<College>()
                .HasData( new College { CollegeId = 1 , College_Name = "Computers & AI College" ,  College_Description = "Description" , Contact_Information = "Contact info"} );

            modelBuilder.Entity<Admin>()
                .HasData(new Admin { Id = 1, Name = "Admin", Email = "admin@mail.com" , Password = "admin123"});

            modelBuilder.Entity<Quality>()
                .HasData(new Quality { Id = 1 , Name = "Quality 1 Name" , Description = "Quality 1 Description"});

        }


    }
}
