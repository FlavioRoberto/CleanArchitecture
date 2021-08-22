using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.ViewModels;
using CleanArchitecture.Domain.Commands;
using CleanArchitecture.Domain.Core.Bus;
using CleanArchitecture.Domain.Interfaces;

namespace CleanArchitecture.Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMediatorHandle _bus;

        public CourseService(ICourseRepository courseRepository,
                             IMediatorHandle bus)
        {
            _courseRepository = courseRepository;
            _bus = bus; 
        }

        public void Create(CourseViewModel course)
        {
            var createCourseCommand = new CreateCourseCommand(
                                             course.Name,
                                             course.Description,
                                             course.ImageUrl
                                            );
            _bus.SendCommand(createCourseCommand);

        }

        public CourseViewModel GetCourses()
        {
            var courses = _courseRepository.GetCourses();
            return new CourseViewModel { Courses = courses };
        }
    }
}
