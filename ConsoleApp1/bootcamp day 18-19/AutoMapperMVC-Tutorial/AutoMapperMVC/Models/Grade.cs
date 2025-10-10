using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoMapperMVC.Models
{
    /// <summary>
    /// Represents a grade record for a specific student and subject
    /// Demonstrates complex entity relationships and business logic
    /// </summary>
    public class Grade
    {
        /// <summary>
        /// Primary key for the grade entity
        /// </summary>
        public int GradeID { get; set; }

        /// <summary>
        /// Foreign key reference to the Student entity
        /// </summary>
        [Required(ErrorMessage = "Student ID is required")]
        [ForeignKey("Student")]
        public int StudentID { get; set; }

        /// <summary>
        /// Subject name for this grade
        /// </summary>
        [Required(ErrorMessage = "Subject is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Subject name must be between 2 and 100 characters")]
        public string Subject { get; set; } = string.Empty;

        /// <summary>
        /// Numeric grade value with precise decimal handling
        /// </summary>
        [Required(ErrorMessage = "Grade value is required")]
        [Range(0, 100, ErrorMessage = "Grade must be between 0 and 100")]
        [Column(TypeName = "decimal(5,2)")]
        public decimal GradeValue { get; set; }

        /// <summary>
        /// Letter grade representation (calculated or manually assigned)
        /// </summary>
        [StringLength(2, ErrorMessage = "Letter grade cannot exceed 2 characters")]
        public string? LetterGrade { get; set; }

        /// <summary>
        /// Date when the grade was recorded
        /// </summary>
        [Required(ErrorMessage = "Grade date is required")]
        [DataType(DataType.Date)]
        [Display(Name = "Grade Date")]
        public DateTime GradeDate { get; set; }

        /// <summary>
        /// Optional teacher comments about the grade
        /// </summary>
        [StringLength(500, ErrorMessage = "Comments cannot exceed 500 characters")]
        [Display(Name = "Teacher Comments")]
        public string? Comments { get; set; }

        /// <summary>
        /// Navigation property back to the Student entity
        /// </summary>
        public virtual Student? Student { get; set; }

        /// <summary>
        /// Business logic method to calculate letter grade from numeric value
        /// This demonstrates domain logic encapsulation
        /// </summary>
        /// <returns>Letter grade representation</returns>
        public string CalculateLetterGrade()
        {
            return GradeValue switch
            {
                >= 97 => "A+",
                >= 93 => "A",
                >= 90 => "A-",
                >= 87 => "B+",
                >= 83 => "B",
                >= 80 => "B-",
                >= 77 => "C+",
                >= 73 => "C",
                >= 70 => "C-",
                >= 67 => "D+",
                >= 63 => "D",
                >= 60 => "D-",
                _ => "F"
            };
        }

        /// <summary>
        /// Determines if the grade represents a passing score
        /// </summary>
        /// <returns>True if grade is passing, false otherwise</returns>
        public bool IsPassingGrade()
        {
            return GradeValue >= 60;
        }

        /// <summary>
        /// Calculates grade points for GPA computation
        /// </summary>
        /// <returns>Grade points on a 4.0 scale</returns>
        public decimal CalculateGradePoints()
        {
            return GradeValue switch
            {
                >= 97 => 4.0m,
                >= 93 => 4.0m,
                >= 90 => 3.7m,
                >= 87 => 3.3m,
                >= 83 => 3.0m,
                >= 80 => 2.7m,
                >= 77 => 2.3m,
                >= 73 => 2.0m,
                >= 70 => 1.7m,
                >= 67 => 1.3m,
                >= 63 => 1.0m,
                >= 60 => 0.7m,
                _ => 0.0m
            };
        }
    }
}