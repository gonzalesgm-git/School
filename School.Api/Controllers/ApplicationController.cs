using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using School.Application.Commands.Applications;
using School.Application.Queries.Applications;
using School.Domain.Dto;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace School.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private ISender _sender;

        public ApplicationController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var res = await _sender.Send(new ApplicationListQuery());
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateApplicationDto dto)
        {
            var application = new Domain.Models.Application()
            {
                ApplicationDate = dto.ApplicationDate,
                CourseId = dto.CourseId,
                StudentId = dto.StudentId
            };

            var res = await _sender.Send(new SaveApplicationCommand(application));
            return Ok(res);

        }

    }
}
