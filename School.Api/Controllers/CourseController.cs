using MediatR;
using Microsoft.AspNetCore.Mvc;
using School.Application.Commands.Courses;
using School.Application.Queries.Courses;
using School.Domain.Dto;
using School.Domain.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace School.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private ISender _sender;

        public CourseController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var res = await _sender.Send(new CourseListQuery());
            return Ok(res);
        }

      
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var res = await _sender.Send(new CourseQuery(id));
            return Ok(res);
        }

        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCourseRequestDto dto)
        {
            var res = await _sender.Send(new SaveCourseCommand(
                new Course() { 
                    Code=dto.Code,
                    Credits=dto.Credits,
                    Title=dto.Title,
                }
            ));

            return Ok(res);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UdpdateCourseRequestDto dto)
        {
            var res = await _sender.Send(new UpdateCourseCommand(
               new Course()
               {
                   Id=id,
                   Code = dto.Code,
                   Credits = dto.Credits,
                   Title = dto.Title
                   
               }
           ));

            return Ok(res);
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _sender.Send(new DeleteCourseCommand(id));
            return Ok(res);
        }
    }
}
