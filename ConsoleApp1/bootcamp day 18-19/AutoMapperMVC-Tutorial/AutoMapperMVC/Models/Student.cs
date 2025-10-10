using System.ComponentModel.DataAnnotations;

namespace AutoMapperMVC.Models
{
    /// <summary>
    /// Represents a student entity in the database
    /// This is the domain model containing all business rules and database relationships
    /// </summary>
    public class Student
    {
        /// <summary>
        /// Primary key for the student entity
        /// </summary>
        public int StudentID { get; set; }

        /// <summary>
        /// Student's full name
        /// Required field with length validation
        /// </summary>
        [Required(ErrorMessage = "Student name is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Student's gender with restricted values
        /// </summary>
        [Required(ErrorMessage = "Gender is required")]
        [RegularExpression("^(Male|Female|Other)$", ErrorMessage = "Gender must be Male, Female, or Other")]
        public string Gender { get; set; } = string.Empty;

        /// <summary>
        /// Academic department or major
        /// </summary>
        [Required(ErrorMessage = "Branch is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Branch must be between 2 and 50 characters")]
        public string Branch { get; set; } = string.Empty;

        /// <summary>
        /// Class section identifier
        /// </summary>
        [Required(ErrorMessage = "Section is required")]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "Section must be between 1 and 10 characters")]
        public string Section { get; set; } = string.Empty;

        /// <summary>
        /// Contact email address with validation
        /// </summary>
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters")]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Optional phone number
        /// </summary>
        [Phone(ErrorMessage = "Please enter a valid phone number")]
        [StringLength(20, ErrorMessage = "Phone number cannot exceed 20 characters")]
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Date when the student enrolled
        /// </summary>
        [Required(ErrorMessage = "Enrollment date is required")]
        [DataType(DataType.Date)]
        [Display(Name = "Enrollment Date")]
        public DateTime EnrollmentDate { get; set; }

        /// <summary>
        /// Timestamp for record creation (audit field)
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Timestamp for last modification (audit field)
        /// </summary>
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Navigation property for related grades
        /// Virtual keyword enables lazy loading
        /// </summary>
        public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();

        /// <summary>
        /// Calculated property for average grade
        /// This demonstrates business logic within the entity
        /// </summary>
        public decimal? CalculateAverageGrade()
        {
            if (Grades == null || !Grades.Any())
                return null;

            return Grades.Average(g => g.GradeValue);
        }
    }
}