using AutoMapperMVC.DTOs;

namespace AutoMapperMVC.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDTO>> GetAllStudentsAsync();
        Task<IEnumerable<StudentDTO>> SearchStudentsAsync(string searchTerm);
        Task<StudentDTO?> GetStudentByIdAsync(int id);
        Task<StudentDTO> CreateStudentAsync(StudentCreateDTO createDto);
        Task<bool> UpdateStudentAsync(int id, StudentDTO studentDto);
        Task<bool> DeleteStudentAsync(int id);
    }
}