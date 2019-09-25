using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Conrec.Application.Models;
using Conrec.Application.Employees.Commands.CreateEmployer;
using Conrec.Application.Employees.Commands.UpdateEmployer;
using Conrec.Application.Employees.Commands.DeleteEmployer;
using Conrec.Application.Employees.Queries.GetEmployerDetail;
using Conrec.Application.User.Queries.GetUserValidation;
using Conrec.Application.Employer.Commands.CreateProject;
using Conrec.Application.Employer.Commands.CreateProjectReport;
using Conrec.Application.Employer.Commands.CreateProjectSchedule;

namespace Conrec.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployerController : BaseController
    {
        // GET: api/Employer/5
        [HttpGet("{id}", Name = "GetEmploye")]
        public async Task<ActionResult<EmployerDetailModel>> Get(int id)
        {
            return Json(await Mediator.Send(new GetEmployerDetailQuery { Id = id }));
        }

        // POST: api/Employer
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateEmployerCommand command)
        {
            var response = await Mediator.Send(command);
 
            return Json(new { Id = response });
        }

        // PUT: api/Employer/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateEmployerCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        // DELETE: api/Employer/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteEmployerCommand { Id = id });

            return NoContent();
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> PostLoginValidator(UserValidatorQuery employerValidatorQuery)
        {
            var response = await Mediator.Send(employerValidatorQuery);

            return Json(response);
        }

        [HttpPost]
        [Route("createProject")]
        public async Task<IActionResult> PostCreateProject(CreateProjectCommand projectCommand)
        {
            await Mediator.Send(projectCommand);

            return NoContent();
        }

        [HttpPost]
        [Route("createProjectReport")]
        public async Task<IActionResult> PostCreateProjectReport(CreateProjectReportCommand projectReportCommand)
        {
            await Mediator.Send(projectReportCommand);

            return NoContent();
        }

        [HttpPost]
        [Route("createProjectSchedule")]
        public async Task<IActionResult> PostCreateProjectSchedule(CreateProjectScheduleCommand createProjecScheduleCommand)
        {
            await Mediator.Send(createProjecScheduleCommand);

            return NoContent();
        }
    }
}
