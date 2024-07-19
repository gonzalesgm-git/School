using MediatR;
using Microsoft.AspNetCore.Mvc;
using School.Application.Commands;
using School.Application.Queries;
using School.Domain.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace School.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private ISender _sender;

        public StudentController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var students = await _sender.Send(new StudentListQuery());
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var student = await _sender.Send(new StudentQuery(id));
            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Student student)
        {
            var res = await _sender.Send(new SaveStudentCommand(student));
            return Ok(res);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Student student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }
            var res = await _sender.Send(new UpdateStudentCommand(student));
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var res =  await _sender.Send(new DeleteStudentCommand(id));
            return Ok(res);
        }
    }
}
