using AutoMapper;
using StudentsApi.Models;
using StudentsApi.Models.DTOs;
using StudentsApi.Repositories;

namespace StudentsApi.Services
{
    public class CourseInstanceService : ICourseInsanceService
    {
        private readonly ICourseInstanceRepository _repository;
        private readonly IMapper _mapper;

        public CourseInstanceService(ICourseInstanceRepository repository, IMapper mapper )
        {
            _repository = repository;
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
    }
}
