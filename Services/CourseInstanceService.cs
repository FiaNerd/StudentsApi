using AutoMapper;
using StudentsApi.Models;
using StudentsApi.Models.DTOs;
using StudentsApi.Repositories;

namespace StudentsApi.Services
{
    public class CourseInstanceService : ICourseInstanceService
    {
        private readonly ICourseInstanceRepository _repository;
        private readonly IMapper _mapper;

        public CourseInstanceService(ICourseInstanceRepository repository, IMapper mapper )
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CourseInstanceDTO>> GetCourseInstances()
        {
            try
            {
                IEnumerable<CourseInstance> courseInstances = await _repository.GetCourseInstances();

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

        public Task<CourseInstanceDTO?> CreateCourseInstance(CourseInstanceDTO courseInstanceDTO)
        {
            try
            {

                throw new NotImplementedException();
                //var addCourseInstance = new CourseInstance(
                //        courseInstanceDTO.StartDate,
                //        courseInstanceDTO.EndDate
                //    );
                //{ 
                //    courseInstanceDTO.Students = addCourseInstance.Students;
                //}; 

                //var createdCourseInstance = _repository.CreateCourseInstance(addCourseInstance);

                //return _mapper.Map<Task<CourseInstanceDTO>>(createdCourseInstance);
            }
            catch (Exception ex)
            {

                throw new Exception("Not working", ex);
            }
        }
    }
}
