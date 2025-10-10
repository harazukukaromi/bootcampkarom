using System.ComponentModel.DataAnnotations;

namespace StudentManagementMVC.Models
{
    public class Grade
    {
        public int GradeID { get; set; }

        // Foreign key to Student
        public int StudentID { get; set; }

        [Required(ErrorMessage = "Subject is required")]
        [StringLength(100, ErrorMessage = "Subject name cannot exceed 100 characters")]
        public string Subject { get; set; } = string.Empty;

        [Required(ErrorMessage = "Grade value is required")]
        [Range(0, 100, ErrorMessage = "Grade must be between 0 and 100")]
        [Display(Name = "Grade (%)")]
        public decimal GradeValue { get; set; }

        [StringLength(2, ErrorMessage = "Letter grade cannot exceed 2 characters")]
        [Display(Name = "Letter Grade")]
        public string? LetterGrade { get; set; }

        [Required(ErrorMessage = "Grade date is required")]
        [DataType(DataType.Date)]
        [Display(Name = "Date Recorded")]
        public DateTime GradeDate { get; set; }

        [StringLength(500, ErrorMessage = "Comments cannot exceed 500 characters")]
        public string? Comments { get; set; }

        // Navigation property back to Student
        public virtual Student Student { get; set; } = null!;
    }
}