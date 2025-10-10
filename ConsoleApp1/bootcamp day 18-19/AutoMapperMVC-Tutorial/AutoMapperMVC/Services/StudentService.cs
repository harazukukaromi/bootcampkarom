using AutoMapperMVC.Data;
using AutoMapperMVC.Models;
using AutoMapperMVC.DTOs;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AutoMapperMVC.Services
{
    public class StudentService : IStudentService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public StudentService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StudentDTO>> GetAllStudentsAsync()
        {
            var students = await _context.Students
                .Include(s => s.Grades)
                .OrderBy(s => s.Name)
                .ToListAsync();

            return _mapper.Map<IEnumerable<StudentDTO>>(students);
        }

        public async Task<IEnumerable<StudentDTO>> SearchStudentsAsync(string searchTerm)
        {
            var query = _context.Students.Include(s => s.Grades).AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(s => s.Name.Contains(searchTerm) ||
                                   s.Branch.Contains(searchTerm) ||
                                   s.Email.Contains(searchTerm));
            }

            var students = await query.OrderBy(s => s.Name).ToListAsync();
            return _mapper.Map<IEnumerable<StudentDTO>>(students);
        }

        public async Task<StudentDTO?> GetStudentByIdAsync(int id)
        {
            var student = await _context.Students
                .Include(s => s.Grades)
                .FirstOrDefaultAsync(s => s.StudentID == id);

            return student != null ? _mapper.Map<StudentDTO>(student) : null;
        }

        public async Task<StudentDTO> CreateStudentAsync(StudentCreateDTO createDto)
        {
            var student = _mapper.Map<Student>(createDto);
            
            if (student.EnrollmentDate == default(DateTime))
            {
                student.EnrollmentDate = DateTime.Today;
            }
            
            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return _mapper.Map<StudentDTO>(student);
        }

        public async Task<bool> UpdateStudentAsync(int id, StudentDTO studentDto)
        {
            var existingStudent = await _context.Students.FindAsync(id);
            if (existingStudent == null)
                return false;

            _mapper.Map(studentDto, existingStudent);
            
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }

        public async Task<bool> DeleteStudentAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
                return false;

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}