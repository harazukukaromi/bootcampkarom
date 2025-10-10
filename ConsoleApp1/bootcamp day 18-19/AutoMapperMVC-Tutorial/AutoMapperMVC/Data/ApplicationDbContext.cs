using Microsoft.EntityFrameworkCore;
using AutoMapperMVC.Models;

namespace AutoMapperMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Student-Grade relationship (One-to-Many)
            modelBuilder.Entity<Grade>()
                .HasOne(g => g.Student)
                .WithMany(s => s.Grades)
                .HasForeignKey(g => g.StudentID)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure decimal precision for GradeValue
            modelBuilder.Entity<Grade>()
                .Property(g => g.GradeValue)
                .HasColumnType("decimal(5,2)");

            // Seed sample data
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    StudentID = 1,
                    Name = "John Doe",
                    Gender = "Male",
                    Branch = "Computer Science",
                    Section = "A",
                    Email = "john.doe@example.com",
                    PhoneNumber = "123-456-7890",
                    EnrollmentDate = new DateTime(2023, 1, 15)
                }
            );

            modelBuilder.Entity<Grade>().HasData(
                new Grade
                {
                    GradeID = 1,
                    StudentID = 1,
                    Subject = "Mathematics",
                    GradeValue = 85.5m,
                    LetterGrade = "B",
                    GradeDate = new DateTime(2023, 6, 15),
                    Comments = "Good performance"
                }
            );
        }
    }
}