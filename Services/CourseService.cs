using AutoMapper;
using StudentsApi.Models.DTOs;
using StudentsApi.Repositories;

namespace StudentsApi.Services
{
    public class CourseService : ICourseService
    {
       private readonly ICourseRepository _repo;
        private readonly IMapper _mapper;

        public CourseService(ICourseRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CourseDTO>> GetAllCourses()
        {
            IEnumerable<Course> courses = await _repo.GetAllCourses();

            return _mapper.Map<IEnumerable<CourseDTO>>(courses);
        }

        public async Task<CourseDTO?> GetCourseById(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Id must not be empty", nameof(id));
            }

            Course? course = await _repo.GetCourseById(id);

            if (course is null)
            {
                throw new KeyNotFoundException($"Could not find a course with id {id}");
            }

            return _mapper.Map<CourseDTO>(course);
        }

        public async Task<CourseDTO> CreateCourse(CreateCourseDTO courseRequest)
        {
            if (string.IsNullOrWhiteSpace(courseRequest.Title))
            { 
                throw new ArgumentException("Course title must not be empty", nameof(courseRequest.Title));
            }

            if(string.IsNullOrWhiteSpace(courseRequest.Description))
            {
                throw new ArgumentException("Course description must not be empty", nameof(courseRequest.Description));
            }

            var newCourse = new Course(
                courseRequest.Title,
                courseRequest.Description
                );

            var createdCourse = await _repo.CreateCourse(newCourse);

            return _mapper.Map<CourseDTO>(createdCourse);

        }

        public async Task<CourseDTO?> UpdateCourse(Guid id, UpdateCourseDTO course)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("Id must not be empty", nameof(id));

            var existingCourse = await _repo.GetCourseById(id)
                ?? throw new Exception($"Course with id {id} not found.");

            // Apply updates only if provided
            if (!string.IsNullOrWhiteSpace(course.Title))
                existingCourse.Title = course.Title;

            if (!string.IsNullOrWhiteSpace(course.Description))
                existingCourse.Description = course.Description;

            // Validate final state (entity, not DTO)
            if (string.IsNullOrWhiteSpace(existingCourse.Title) ||
                string.IsNullOrWhiteSpace(existingCourse.Description))
            {
                throw new ArgumentException("Course must always have both title and description.");
            }

            //Course updateCoure = new Course(
            //    existingCourse.Title,
            //    existingCourse.Description
            //    )
            //{
            //    Id = existingCourse.Id
            //};

            await _repo.UpdateCourse(id,existingCourse);

            return _mapper.Map<CourseDTO>(existingCourse);
        }

        public async Task<Course?> DeleteCourse(Guid id)
        {
            var courseDeleted = await _repo.DeleteCourse(id);

            return courseDeleted == null ?
                  throw new InvalidOperationException($"Student with ID {id} could not be deleted because it does not exist.")
                : courseDeleted;
        }
    }
}
