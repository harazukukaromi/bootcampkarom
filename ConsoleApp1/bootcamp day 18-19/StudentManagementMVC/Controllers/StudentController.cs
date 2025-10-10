using Microsoft.AspNetCore.Mvc;
using StudentManagementMVC.Models;
using StudentManagementMVC.Services;

namespace StudentManagementMVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // GET: Student
        public async Task<IActionResult> Index(string searchString)
        {
            IEnumerable<Student> students;

            if (!string.IsNullOrEmpty(searchString))
            {
                students = await _studentService.SearchStudentsAsync(searchString);
                ViewData["CurrentFilter"] = searchString;
            }
            else
            {
                students = await _studentService.GetAllStudentsAsync();
            }

            return View(students);
        }

        // GET: Student/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var student = await _studentService.GetStudentByIdAsync(id.Value);
            if (student == null) return NotFound();

            return View(student);
        }

        // GET: Student/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student student)
        {
            if (ModelState.IsValid)
            {
                await _studentService.CreateStudentAsync(student);
                TempData["SuccessMessage"] = "Student created successfully!";
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Student/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var student = await _studentService.GetStudentByIdAsync(id.Value);
            if (student == null) return NotFound();

            return View(student);
        }

        // POST: Student/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Student student)
        {
            if (id != student.StudentID) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    await _studentService.UpdateStudentAsync(student);
                    TempData["SuccessMessage"] = "Student updated successfully!";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Unable to save changes.");
                }
            }
            return View(student);
        }

        // GET: Student/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var student = await _studentService.GetStudentByIdAsync(id.Value);
            if (student == null) return NotFound();

            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var success = await _studentService.DeleteStudentAsync(id);
            if (success)
            {
                TempData["SuccessMessage"] = "Student deleted successfully!";
            }
            else
            {
                TempData["ErrorMessage"] = "Error deleting student.";
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Student/Grades/5
        public async Task<IActionResult> Grades(int? id)
        {
            if (id == null) return NotFound();

            var student = await _studentService.GetStudentByIdAsync(id.Value);
            if (student == null) return NotFound();

            ViewBag.Student = student;
            var grades = await _studentService.GetGradesByStudentIdAsync(id.Value);
            return View(grades);
        }

        // GET: Student/AddGrade/5
        public async Task<IActionResult> AddGrade(int? id)
        {
            if (id == null) return NotFound();

            var student = await _studentService.GetStudentByIdAsync(id.Value);
            if (student == null) return NotFound();

            ViewBag.Student = student;
            var grade = new Grade { StudentID = id.Value };
            return View(grade);
        }

        // POST: Student/AddGrade
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddGrade(Grade grade)
        {
            if (ModelState.IsValid)
            {
                await _studentService.AddGradeAsync(grade);
                TempData["SuccessMessage"] = "Grade added successfully!";
                return RedirectToAction(nameof(Grades), new { id = grade.StudentID });
            }

            var student = await _studentService.GetStudentByIdAsync(grade.StudentID);
            ViewBag.Student = student;
            return View(grade);
        }
    }
}