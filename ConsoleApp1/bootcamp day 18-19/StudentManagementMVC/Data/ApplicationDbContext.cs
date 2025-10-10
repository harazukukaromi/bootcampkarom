using Microsoft.EntityFrameworkCore;
using StudentManagementMVC.Models;

namespace StudentManagementMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSet properties represent tables in your database
        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships
            modelBuilder.Entity<Grade>()
                .HasOne(g => g.Student)
                .WithMany(s => s.Grades)
                .HasForeignKey(g => g.StudentID)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure decimal precision for grades
            modelBuilder.Entity<Grade>()
                .Property(g => g.GradeValue)
                .HasColumnType("decimal(5,2)");

            // Seed initial data
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            // Seed Students
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    StudentID = 1,
                    Name = "John Smith",
                    Gender = "Male",
                    Branch = "Computer Science",
                    Section = "A",
                    Email = "john.smith@university.edu",
                    EnrollmentDate = new DateTime(2023, 9, 1)
                },
                new Student
                {
                    StudentID = 2,
                    Name = "Sarah Johnson",
                    Gender = "Female",
                    Branch = "Engineering",
                    Section = "B",
                    Email = "sarah.johnson@university.edu",
                    EnrollmentDate = new DateTime(2023, 9, 1)
                },
                new Student
                {
                    StudentID = 3,
                    Name = "Mike Davis",
                    Gender = "Male",
                    Branch = "Business Administration",
                    Section = "A",
                    Email = "mike.davis@university.edu",
                    EnrollmentDate = new DateTime(2024, 1, 15)
                }
            );

            // Seed Grades
            modelBuilder.Entity<Grade>().HasData(
                new Grade
                {
                    GradeID = 1,
                    StudentID = 1,
                    Subject = "Data Structures",
                    GradeValue = 95.5m,
                    LetterGrade = "A",
                    GradeDate = new DateTime(2024, 3, 15),
                    Comments = "Excellent understanding of algorithms"
                },
                new Grade
                {
                    GradeID = 2,
                    StudentID = 1,
                    Subject = "Web Development",
                    GradeValue = 88.0m,
                    LetterGrade = "B",
                    GradeDate = new DateTime(2024, 4, 20),
                    Comments = "Good work on MVC project"
                },
                new Grade
                {
                    GradeID = 3,
                    StudentID = 2,
                    Subject = "Calculus",
                    GradeValue = 92.0m,
                    LetterGrade = "A",
                    GradeDate = new DateTime(2024, 3, 10),
                    Comments = "Strong mathematical foundation"
                }
            );
        }
    }
}