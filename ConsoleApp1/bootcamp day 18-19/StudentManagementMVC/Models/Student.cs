using System.ComponentModel.DataAnnotations;

namespace StudentManagementMVC.Models
{
    public class Student
    {
        // Primary key - Entity Framework recognizes this pattern
        public int StudentID { get; set; }

        [Required(ErrorMessage = "Student name is required")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Gender is required")]
        [RegularExpression("^(Male|Female|Other)$", 
            ErrorMessage = "Gender must be Male, Female, or Other")]
        public string Gender { get; set; } = string.Empty;

        [Required(ErrorMessage = "Branch is required")]
        [StringLength(50, ErrorMessage = "Branch cannot exceed 50 characters")]
        public string Branch { get; set; } = string.Empty;

        [Required(ErrorMessage = "Section is required")]
        [StringLength(10, ErrorMessage = "Section cannot exceed 10 characters")]
        public string Section { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Enrollment date is required")]
        [DataType(DataType.Date)]
        [Display(Name = "Enrollment Date")]
        public DateTime EnrollmentDate { get; set; }

        // Navigation property for one-to-many relationship
        public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();
    }
}