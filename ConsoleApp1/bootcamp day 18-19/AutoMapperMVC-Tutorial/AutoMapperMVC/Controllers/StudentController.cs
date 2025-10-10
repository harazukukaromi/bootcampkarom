using Microsoft.AspNetCore.Mvc;
using AutoMapperMVC.Services;
using AutoMapperMVC.DTOs;

namespace AutoMapperMVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public async Task<IActionResult> Index(string searchTerm)
        {
            var students = await _studentService.SearchStudentsAsync(searchTerm ?? string.Empty);
            ViewBag.SearchTerm = searchTerm;
            return View(students);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return BadRequest("Student ID is required");

            var student = await _studentService.GetStudentByIdAsync(id.Value);
            if (student == null)
                return NotFound($"Student with ID {id} not found");

            return View(student);
        }

        public IActionResult Create()
        {
            return View(new StudentCreateDTO 
            { 
                EnrollmentDate = DateTime.Today 
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentCreateDTO createDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var studentDto = await _studentService.CreateStudentAsync(createDto);
                    TempData["SuccessMessage"] = $"Student {studentDto.FullName} created successfully!";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Error creating student: {ex.Message}");
                }
            }

            return View(createDto);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return BadRequest("Student ID is required");

            var student = await _studentService.GetStudentByIdAsync(id.Value);
            if (student == null)
                return NotFound($"Student with ID {id} not found");

            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, StudentDTO studentDto)
        {
            if (id != studentDto.Id)
                return BadRequest("ID mismatch");

            if (ModelState.IsValid)
            {
                try
                {
                    var success = await _studentService.UpdateStudentAsync(id, studentDto);
                    if (!success)
                        return NotFound($"Student with ID {id} not found");
                    
                    TempData["SuccessMessage"] = $"Student {studentDto.FullName} updated successfully!";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Error updating student: {ex.Message}");
                }
            }

            return View(studentDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _studentService.DeleteStudentAsync(id);
            if (!success)
                return NotFound($"Student with ID {id} not found");

            TempData["SuccessMessage"] = "Student deleted successfully!";
            return RedirectToAction(nameof(Index));
        }
    }
}