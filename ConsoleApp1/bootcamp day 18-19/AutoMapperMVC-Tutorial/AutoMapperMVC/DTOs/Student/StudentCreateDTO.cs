using System.ComponentModel.DataAnnotations;

namespace AutoMapperMVC.DTOs.Student
{
    /// <summary>
    /// Data Transfer Object for creating new students
    /// Contains only the fields necessary for student creation
    /// Includes comprehensive validation rules for data integrity
    /// </summary>
    public class StudentCreateDTO
    {
        /// <summary>
        /// Student's full name with validation rules
        /// </summary>
        [Required(ErrorMessage = "Student name is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters")]
        [Display(Name = "Full Name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Student's gender with restricted options
        /// </summary>
        [Required(ErrorMessage = "Gender is required")]
        [RegularExpression("^(Male|Female|Other)$", ErrorMessage = "Gender must be Male, Female, or Other")]
        [Display(Name = "Gender")]
        public string Gender { get; set; } = string.Empty;

        /// <summary>
        /// Academic branch or department
        /// </summary>
        [Required(ErrorMessage = "Branch is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Branch must be between 2 and 50 characters")]
        [Display(Name = "Academic Branch")]
        public string Branch { get; set; } = string.Empty;

        /// <summary>
        /// Class section with specific format requirements
        /// </summary>
        [Required(ErrorMessage = "Section is required")]
        [RegularExpression("^[A-Z]$", ErrorMessage = "Section must be a single uppercase letter (A-Z)")]
        [Display(Name = "Section")]
        public string Section { get; set; } = string.Empty;

        /// <summary>
        /// Email address with format validation
        /// </summary>
        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters")]
        [Display(Name = "Email Address")]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Optional phone number with format validation
        /// </summary>
        [Phone(ErrorMessage = "Please enter a valid phone number")]
        [StringLength(20, ErrorMessage = "Phone number cannot exceed 20 characters")]
        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Enrollment date with default value
        /// </summary>
        [Required(ErrorMessage = "Enrollment date is required")]
        [DataType(DataType.Date)]
        [Display(Name = "Enrollment Date")]
        public DateTime EnrollmentDate { get; set; } = DateTime.Today;

        /// <summary>
        /// Custom validation method to ensure enrollment date is not in the future
        /// </summary>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (EnrollmentDate > DateTime.Today)
            {
                yield return new ValidationResult(
                    "Enrollment date cannot be in the future",
                    new[] { nameof(EnrollmentDate) });
            }

            if (EnrollmentDate < DateTime.Today.AddYears(-10))
            {
                yield return new ValidationResult(
                    "Enrollment date cannot be more than 10 years ago",
                    new[] { nameof(EnrollmentDate) });
            }
        }
    }
}