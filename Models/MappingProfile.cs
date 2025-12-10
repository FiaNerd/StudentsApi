using AutoMapper;
using StudentsApi.Models.DTOs;
using StudentsApi.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Course mappings
        CreateMap<Course, CourseDTO>();
        CreateMap<Course, CourseSummaryDTO>();

        // CourseInstance mappings
        CreateMap<CourseInstance, CourseInstanceDTO>()
            .ForMember(dest => dest.Course, opt => opt.MapFrom(src => src.Course))
            .ForMember(dest => dest.Students, opt => opt.MapFrom(src => src.Students));

        CreateMap<CourseInstance, CourseInstanceSummaryDTO>();

        // Student mappings
        CreateMap<Student, StudentDTO>();
        CreateMap<Student, StudentSummaryDTO>();

    }
}