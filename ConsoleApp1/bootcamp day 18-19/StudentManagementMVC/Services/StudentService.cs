using Microsoft.EntityFrameworkCore;
using StudentManagementMVC.Data;
using StudentManagementMVC.Models;

namespace StudentManagementMVC.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAllStudentsAsync();
        Task<Student?> GetStudentByIdAsync(int id);
        Task<Student> CreateStudentAsync(Student student);
        Task<Student> UpdateStudentAsync(Student student);
        Task<bool> DeleteStudentAsync(int id);
        Task<IEnumerable<Student>> SearchStudentsAsync(string searchTerm);
        Task<IEnumerable<Grade>> GetGradesByStudentIdAsync(int studentId);
        Task<Grade> AddGradeAsync(Grade grade);
    }

    public class StudentService : IStudentService
    {
        private readonly ApplicationDbContext _context;

        public StudentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await _context.Students
                .Include(s => s.Grades)
                .OrderBy(s => s.Name)
                .ToListAsync();
        }

        public async Task<Student?> GetStudentByIdAsync(int id)
        {
            return await _context.Students
                .Include(s => s.Grades)
                .FirstOrDefaultAsync(s => s.StudentID == id);
        }

        public async Task<Student> CreateStudentAsync(Student student)
        {
            if (student.EnrollmentDate == default(DateTime))
                student.EnrollmentDate = DateTime.Today;

            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<Student> UpdateStudentAsync(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<bool> DeleteStudentAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null) return false;

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Student>> SearchStudentsAsync(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return await GetAllStudentsAsync();

            return await _context.Students
                .Include(s => s.Grades)
                .Where(s => s.Name.Contains(searchTerm) || 
                           s.Branch.Contains(searchTerm) || 
                           s.Section.Contains(searchTerm))
                .OrderBy(s => s.Name)
                .ToListAsync();
        }

        public async Task<IEnumerable<Grade>> GetGradesByStudentIdAsync(int studentId)
        {
            return await _context.Grades
                .Where(g => g.StudentID == studentId)
                .OrderBy(g => g.Subject)
                .ToListAsync();
        }

        public async Task<Grade> AddGradeAsync(Grade grade)
        {
            // Auto-calculate letter grade
            grade.LetterGrade = CalculateLetterGrade(grade.GradeValue);
            
            if (grade.GradeDate == default(DateTime))
                grade.GradeDate = DateTime.Today;

            _context.Grades.Add(grade);
            await _context.SaveChangesAsync();
            return grade;
        }

        private string CalculateLetterGrade(decimal gradeValue)
        {
            return gradeValue switch
            {
                >= 97 => "A+",
                >= 93 => "A",
                >= 90 => "A-",
                >= 87 => "B+",
                >= 83 => "B",
                >= 80 => "B-",
                >= 77 => "C+",
                >= 73 => "C",
                >= 70 => "C-",
                >= 67 => "D+",
                >= 60 => "D",
                _ => "F"
            };
        }
    }
}