using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentsApi.Models;
using StudentsApi.Models.DTOs;
using StudentsApi.Repositories;

namespace StudentsApi.Services
{
    public class CourseInstanceService : ICourseInstanceService
    {
        private readonly ICourseInstanceRepository _repository;
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public CourseInstanceService(ICourseInstanceRepository repository, ICourseRepository courseRepository, IMapper mapper )
        {
            _repository = repository;
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CourseInstanceDTO>> GetAllCourseInstances()
        {
            try
            {
                IEnumerable<CourseInstance> courseInstances = await _repository.GetAllCourseInstances();

                return _mapper.Map<IEnumerable<CourseInstanceDTO>>(courseInstances);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<CourseInstanceDTO?> GetCourseInstanceById(Guid id)
        {
            try
            {   
                var exist = await _repository.Exists(id, DateTime.MinValue, DateTime.MinValue);

                if (exist) { 
                    throw new Exception("Course Instance already exists");
                }

                var result = await _repository.GetCourseInstanceById(id);

                if(result == null)
                {
                    throw new Exception("Course Instance not found");
                }

                return _mapper.Map<CourseInstanceDTO>(result);
            }
            catch (Exception ex)
            {

                throw new Exception("Something wrong!", ex);
            }
        }

        public async Task<CourseInstanceDTO> CreateCourseInstance(CreateCourseInstanceDTO dto)
        {
            // Validate course exists
            var course = await _courseRepository.GetCourseById(dto.CourseId);
            if (course == null)
            {
                throw new KeyNotFoundException($"Course with id {dto.CourseId} not found.");
            }

            // Check for duplicates
            var exists = await _repository.Exists(dto.CourseId, dto.StartDate, dto.EndDate);

            if (exists)
            {
                throw new InvalidOperationException("CourseInstance already exists for this course and date range.");
            }

            // Create entity
            var addCourseInstance = new CourseInstance(dto.StartDate, dto.EndDate)
            {
                Id = Guid.NewGuid(),
                CourseId = dto.CourseId
            };

            // Save via repository
            var createdCourseInstance = await _repository.CreateCourseInstance(addCourseInstance);

            return _mapper.Map<CourseInstanceDTO>(createdCourseInstance);
        }
    }
}
