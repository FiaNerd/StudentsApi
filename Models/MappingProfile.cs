using AutoMapper;
using StudentsApi.Models.DTOs;

namespace StudentsApi.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Course, CourseDTO>();
            CreateMap<Course, CourseSummaryDTO>();
            CreateMap<CourseInstance, CourseInstanceDTO>();
            CreateMap<CourseInstance, CourseInstanceSummaryDTO>();
            CreateMap<Student, StudentDTO>();
            CreateMap<Student, StudentInfoDTO>();
        }
    }
}
