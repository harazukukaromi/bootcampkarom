// DTOs/Grade/GradeDTO.cs - For displaying grade information
using System.ComponentModel.DataAnnotations;

namespace AutoMapperMVC.DTOs.Grade
{
    /// <summary>
    /// DTO for displaying grade information
    /// Contains computed fields and formatted display properties
    /// </summary>
    public class GradeDTO
    {
        /// <summary>
        /// Grade identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Associated student's name for display purposes
        /// This will be populated through AutoMapper from navigation properties
        /// </summary>
        [Display(Name = "Student Name")]
        public string StudentName { get; set; } = string.Empty;

        /// <summary>
        /// Subject name
        /// </summary>
        [Display(Name = "Subject")]
        public string Subject { get; set; } = string.Empty;

        /// <summary>
        /// Numeric grade value
        /// </summary>
        [Display(Name = "Grade")]
        [DisplayFormat(DataFormatString = "{0:F1}", ApplyFormatInEditMode = false)]
        public decimal GradeValue { get; set; }

        /// <summary>
        /// Letter grade representation
        /// </summary>
        [Display(Name = "Letter Grade")]
        public string? LetterGrade { get; set; }

        /// <summary>
        /// Date when grade was recorded
        /// </summary>
        [Display(Name = "Grade Date")]
        [DataType(DataType.Date)]
        public DateTime GradeDate { get; set; }

        /// <summary>
        /// Teacher comments
        /// </summary>
        [Display(Name = "Comments")]
        public string? Comments { get; set; }

        /// <summary>
        /// Indicates if this is a passing grade
        /// This property will be computed during mapping
        /// </summary>
        [Display(Name = "Status")]
        public bool IsPassingGrade { get; set; }

        /// <summary>
        /// Grade points for GPA calculation
        /// </summary>
        [Display(Name = "Grade Points")]
        [DisplayFormat(DataFormatString = "{0:F1}", ApplyFormatInEditMode = false)]
        public decimal GradePoints { get; set; }

        /// <summary>
        /// Formatted display string for the grade
        /// </summary>
        public string GradeDisplayText => $"{GradeValue:F1} ({LetterGrade})";
    }
}