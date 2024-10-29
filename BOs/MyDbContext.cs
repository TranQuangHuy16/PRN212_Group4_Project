using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BOs
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() 
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<CourseSemester> CourseSemesters { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<Semester> Semesters { get; set; }
        public virtual DbSet<Slot> Slots { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Using IConfiguration to get information from json file.
            optionsBuilder.UseSqlServer("Server= QUANGHUY\\PIEDTEAM;Database= Group4Project; Uid=sa; Pwd=1234567890;TrustServerCertificate=true");
        }

        

        protected override void OnModelCreating(ModelBuilder optionsBuilder)
        {
            optionsBuilder.Entity<CourseSemester>()
        .HasKey(cs => new { cs.CourseId, cs.SemesterId }); // Composite key

            optionsBuilder.Entity<CourseSemester>()
                .HasOne(cs => cs.Course)
                .WithMany(c => c.CourseSemesters)
                .HasForeignKey(cs => cs.CourseId);

            optionsBuilder.Entity<CourseSemester>()
                .HasOne(cs => cs.Semester)
                .WithMany(s => s.CourseSemesters)
                .HasForeignKey(cs => cs.SemesterId);




            optionsBuilder.Entity<Account>().HasData(new Account
            {
                AccountId = 1,
                Name = "Admin User",
                Email = "admin@example.com",
                Password = "123456789",
                Telephone = "0123456789",
                Role = 0,
                Status = 1
            });

        }
    }
}
