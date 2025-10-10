using AutoMapper;
using AutoMapperMVC.DTOs.Grade;
using AutoMapperMVC.Models;

namespace AutoMapperMVC.MappingProfiles
{
    public class GradeMappingProfile : Profile
    {
        public GradeMappingProfile()
        {
            // Entity to DTO mapping
            CreateMap<Grade, GradeDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.GradeID))
                .ForMember(dest => dest.StudentName, opt => opt.MapFrom(src => 
                    src.Student != null ? src.Student.Name : "Unknown Student"))
                .AfterMap((src, dest) =>
                {
                    // Ensure letter grade is calculated if missing
                    if (string.IsNullOrEmpty(dest.LetterGrade))
                    {
                        dest.LetterGrade = CalculateLetterGrade(dest.GradeValue);
                    }
                });

            // CreateDTO to Entity mapping
            CreateMap<GradeCreateDTO, Grade>()
                .ForMember(dest => dest.GradeID, opt => opt.Ignore()) // Auto-generated
                .ForMember(dest => dest.Student, opt => opt.Ignore()) // Loaded separately
                .AfterMap((src, dest) =>
                {
                    // Auto-calculate letter grade if not provided
                    if (string.IsNullOrEmpty(dest.LetterGrade))
                    {
                        dest.LetterGrade = CalculateLetterGrade(dest.GradeValue);
                    }
                    
                    // Set grade date to today if not specified
                    if (dest.GradeDate == default)
                    {
                        dest.GradeDate = DateTime.Today;
                    }
                });

            // Reverse mapping for editing
            CreateMap<Grade, GradeCreateDTO>()
                .ForMember(dest => dest.GradeDate, opt => opt.MapFrom(src => src.GradeDate.Date));
        }

        /// <summary>
        /// Business logic: Calculate letter grade from numeric value
        /// </summary>
        /// <param name="gradeValue">Numeric grade (0-100)</param>
        /// <returns>Letter grade (A, B, C, D, F)</returns>
        private static string CalculateLetterGrade(decimal gradeValue)
        {
            return gradeValue switch
            {
                >= 90 => "A",
                >= 80 => "B",
                >= 70 => "C",
                >= 60 => "D",
                _ => "F"
            };
        }
    }
}