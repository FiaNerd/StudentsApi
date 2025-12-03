using AutoMapper;
using StudentsApi.Models.DTOs;

namespace StudentsApi.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Course, CourseDTO>();
            CreateMap<Course, CourseWithInstancesDTO>();
            CreateMap<CourseInstance, CourseInstanceDTO>();
            CreateMap<Student, StudentDTO>();
        }
    }
}
