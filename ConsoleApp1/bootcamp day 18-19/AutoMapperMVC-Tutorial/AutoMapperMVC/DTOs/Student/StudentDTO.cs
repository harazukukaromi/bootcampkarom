using System.ComponentModel.DataAnnotations;

namespace AutoMapperMVC.DTOs.Student
{
    /// <summary>
    /// Data Transfer Object for displaying student information
    /// This DTO exposes only the data that should be visible to clients
    /// Property names may differ from entity properties to provide better API contracts
    /// </summary>
    public class StudentDTO
    {
        /// <summary>
        /// Student identifier (mapped from StudentID in entity)
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Student's display name (mapped from Name in entity)
        /// </summary>
        [Display(Name = "Full Name")]
        public string FullName { get; set; } = string.Empty;

        /// <summary>
        /// Student's gender
        /// </summary>
        [Display(Name = "Gender")]
        public string Gender { get; set; } = string.Empty;

        /// <summary>
        /// Academic department (mapped from Branch in entity)
        /// This demonstrates property name transformation during mapping
        /// </summary>
        [Display(Name = "Department")]
        public string Department { get; set; } = string.Empty;

        /// <summary>
        /// Class section
        /// </summary>
        [Display(Name = "Section")]
        public string Section { get; set; } = string.Empty;

        /// <summary>
        /// Contact email address
        /// </summary>
        [Display(Name = "Email Address")]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Optional phone number
        /// </summary>
        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Enrollment date
        /// </summary>
        [Display(Name = "Enrollment Date")]
        [DataType(DataType.Date)]
        public DateTime EnrollmentDate { get; set; }

        /// <summary>
        /// Collection of related grades
        /// This will be mapped from the Student.Grades navigation property
        /// </summary>
        public List<GradeDTO> Grades { get; set; } = new List<GradeDTO>();

        /// <summary>
        /// Calculated average grade for display purposes
        /// This can be computed during mapping or retrieved from entity
        /// </summary>
        [Display(Name = "Average Grade")]
        [DisplayFormat(DataFormatString = "{0:F2}", NullDisplayText = "No grades")]
        public decimal? AverageGrade { get; set; }

        /// <summary>
        /// Formatted display text for enrollment information
        /// </summary>
        public string EnrollmentDisplayText => $"Enrolled on {EnrollmentDate:MMMM dd, yyyy}";
    }
}