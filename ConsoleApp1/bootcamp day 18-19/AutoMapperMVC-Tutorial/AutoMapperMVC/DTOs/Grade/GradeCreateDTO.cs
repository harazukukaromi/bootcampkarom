using System.ComponentModel.DataAnnotations;

namespace AutoMapperMVC.DTOs.Grade
{
    /// <summary>
    /// Data Transfer Object for creating new grades
    /// Contains validation rules and required fields for grade creation
    /// </summary>
    public class GradeCreateDTO
    {
        /// <summary>
        /// Student identifier for the grade
        /// </summary>
        [Required(ErrorMessage = "Student selection is required")]
        [Display(Name = "Student")]
        public int StudentID { get; set; }

        /// <summary>
        /// Subject name with validation
        /// </summary>
        [Required(ErrorMessage = "Subject is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Subject must be between 2 and 100 characters")]
        [Display(Name = "Subject")]
        public string Subject { get; set; } = string.Empty;

        /// <summary>
        /// Numeric grade value with range validation
        /// </summary>
        [Required(ErrorMessage = "Grade value is required")]
        [Range(0, 100, ErrorMessage = "Grade must be between 0 and 100")]
        [Display(Name = "Grade Value")]
        public decimal GradeValue { get; set; }

        /// <summary>
        /// Date when grade was recorded
        /// </summary>
        [Required(ErrorMessage = "Grade date is required")]
        [DataType(DataType.Date)]
        [Display(Name = "Grade Date")]
        public DateTime GradeDate { get; set; } = DateTime.Today;

        /// <summary>
        /// Optional teacher comments
        /// </summary>
        [StringLength(500, ErrorMessage = "Comments cannot exceed 500 characters")]
        [Display(Name = "Teacher Comments")]
        public string? Comments { get; set; }
    }
}