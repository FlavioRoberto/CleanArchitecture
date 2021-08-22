using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CleanArchitecture.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService; 
        }

        [HttpPost]
        public IActionResult Post([FromBody] CourseViewModel courseViewModel)
        {
            try
            {
                _courseService.Create(courseViewModel);
                return Ok(courseViewModel);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
