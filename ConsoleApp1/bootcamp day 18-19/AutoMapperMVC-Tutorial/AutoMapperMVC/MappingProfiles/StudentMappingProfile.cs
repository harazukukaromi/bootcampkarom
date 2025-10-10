using AutoMapper;
using AutoMapperMVC.DTOs;
using AutoMapperMVC.Models;

namespace AutoMapperMVC.MappingProfiles
{
    public class StudentMappingProfile : Profile
    {
        public StudentMappingProfile()
        {
            // Entity to DTO mappings
            CreateMap<Student, StudentDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.StudentID))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.Branch))
                .ForMember(dest => dest.Grades, opt => opt.MapFrom(src => src.Grades));

            // CreateDTO to Entity mapping
            CreateMap<StudentCreateDTO, Student>()
                .ForMember(dest => dest.StudentID, opt => opt.Ignore())
                .ForMember(dest => dest.Grades, opt => opt.Ignore());

            // DTO to Entity mapping for updates
            CreateMap<StudentDTO, Student>()
                .ForMember(dest => dest.StudentID, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.FullName))
                .ForMember(dest => dest.Branch, opt => opt.MapFrom(src => src.Department))
                .ForMember(dest => dest.Grades, opt => opt.Ignore());
        }
    }
}