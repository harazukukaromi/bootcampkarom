using System.ComponentModel.DataAnnotations;

namespace AutoMapperMVC.DTOs.Student
{
    /// <summary>
    /// Data Transfer Object for updating existing students
    /// Contains ID for identification and editable fields
    /// Some fields like enrollment date may be restricted from editing
    /// </summary>
    public class StudentUpdateDTO
    {
        /// <summary>
        /// Student identifier (required for update operations)
        /// </summary>
        [Required(ErrorMessage = "Student ID is required")]
        public int Id { get; set; }

        /// <summary>
        /// Updated student name
        /// </summary>
        [Required(ErrorMessage = "Student name is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters")]
        [Display(Name = "Full Name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Updated academic branch
        /// </summary>
        [Required(ErrorMessage = "Branch is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Branch must be between 2 and 50 characters")]
        [Display(Name = "Academic Branch")]
        public string Branch { get; set; } = string.Empty;

        /// <summary>
        /// Updated section
        /// </summary>
        [Required(ErrorMessage = "Section is required")]
        [RegularExpression("^[A-Z]$", ErrorMessage = "Section must be a single uppercase letter (A-Z)")]
        [Display(Name = "Section")]
        public string Section { get; set; } = string.Empty;

        /// <summary>
        /// Updated email address
        /// </summary>
        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters")]
        [Display(Name = "Email Address")]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Updated phone number
        /// </summary>
        [Phone(ErrorMessage = "Please enter a valid phone number")]
        [StringLength(20, ErrorMessage = "Phone number cannot exceed 20 characters")]
        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }

        // Note: Gender and EnrollmentDate are typically not editable after creation
        // This design decision reflects business rules about immutable student data
    }
}