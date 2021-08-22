using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.ViewModels;
using CleanArchitecture.Domain.Commands;
using CleanArchitecture.Domain.Core.Bus;
using CleanArchitecture.Domain.Interfaces;
using System.Collections.Generic;

namespace CleanArchitecture.Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMediatorHandle _bus;
        private readonly IMapper _mapper;

        public CourseService(ICourseRepository courseRepository,
                             IMediatorHandle bus,
                             IMapper mapper)
        {
            _courseRepository = courseRepository;
            _bus = bus; 
            _mapper = mapper;
        }

        public void Create(CourseViewModel course)
        {
            var createCourseCommand = _mapper.Map<CreateCourseCommand>(course);
            _bus.SendCommand(createCourseCommand);

        }

        public IEnumerable<CourseViewModel> GetCourses()
        {
            return _courseRepository.GetCourses().ProjectTo<CourseViewModel>(_mapper.ConfigurationProvider);
        }
    }
}
