using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Conrec.Application.Employees.Commands.CreateEmployee;
using Conrec.Application.Employees.Commands.DeleteEmployee;
using Conrec.Application.Employees.Commands.UpdateEmployee;
using Conrec.Application.Employees.Commands.CreateTeam;
using Conrec.Application.Employees.Commands.AttachTeam;
using Conrec.Application.Employees.Commands.CreateDocument;
using Conrec.Application.Employees.Commands.AttachProject;
using Conrec.Application.Employees.Commands.CreateProjectFeedback;
using Conrec.Application.Employees.Queries.GetEmployeeDetail;
using Conrec.Application.Employees.Queries.GetEmployeeProfile;
using Conrec.Application.Employees.Queries.GetAttachmentsAndAdditionalInfo;
using Conrec.Application.Employees.Queries.GetProjectDetails;
using Conrec.Application.Employees.Queries.GetProjectSchedulePerWeek;
using Conrec.Application.Employees.Queries.GetProjectEmployeePerformance;
using Conrec.Application.Employees.Queries.GetPreviousProjectsAndReviews;

namespace Conrec.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : BaseController
    {
        // GET: api/Employee
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Employee/5
        [HttpGet("{id}", Name = "GetEmployee")]
        public async Task<ActionResult<ProjectDetailsModel>> Get(int id)
        {
            return Json(await Mediator.Send(new GetProjectSchedulePerWeekQuery { Id = id }));
        }

        [HttpGet("GetEmployeeProfile/{id}")]
        public async Task<ActionResult<EmployeeProfileModel>> GetEmployeeProfile(int id)
        {
            return Json(await Mediator.Send(new GetEmployeeProfileQuery { Id = id }));
        }

        [HttpGet("GetAttachmentsAndAdditionalInfo/{id}")]
        public async Task<ActionResult<AttachmentsAndAdditionalInfoModel>> GetAttachmentsAndAdditionalInfo(int id)
        {
            return Json(await Mediator.Send(new GetAttachmentsAndAdditionalInfoQuery { Id = id }));
        }

        [HttpGet("GetCurrentProjectDetails/{id}")]
        public async Task<ActionResult<ProjectDetailsModel>> GetCurrentProjectDetails(int id)
        {
            return Json(await Mediator.Send(new GetProjectDetailsQuery { Id = id }));
        }

        [HttpGet("GetProjectSchedulePerWeek/{id}")]
        public async Task<ActionResult<ProjectSchedulePerWeekModel>> GetProjectSchedulePerWeek(int id)
        {
            return Json(await Mediator.Send(new GetProjectSchedulePerWeekQuery { Id = id }));
        }

        [HttpGet("GetProjectEmployeePerformance/{id}")]
        public async Task<ActionResult<ProjectEmployeePerformanceModel>> GetProjectEmployeePerformance(int id)
        {
            return Json(await Mediator.Send(new GetProjectEmployeePerformanceQuery { Id = id }));
        }

        [HttpGet("GetPreviousProjectsAndReviews/{id}")]
        public async Task<ActionResult<PreviousProjectsAndReviewsModel>> GetPreviousProjectsAndReviews(int id)
        {
            return Json(await Mediator.Send(new GetPreviousProjectsAndReviewsQuery { Id = id }));
        }

        // POST: api/Employee
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateEmployeeCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        // PUT: api/Employee/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateEmployeeCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteEmployeeCommand { Id = id });

            return NoContent();
        }


        [HttpPost]
        [Route("createTeam")]
        public async Task<IActionResult> PostCreateTeam(CreateTeamCommand createTeamCommand)
        {
            await Mediator.Send(createTeamCommand);

            return NoContent();
        }


        [HttpPost]
        [Route("attachTeam")]
        public async Task<IActionResult> PostAttachTeam(AttachTeamCommand attachTeamCommand)
        {
            await Mediator.Send(attachTeamCommand);

            return NoContent();
        }

        [HttpPost]
        [Route("attachProject")]
        public async Task<IActionResult> PostAttachProject(AttachProjectCommand attachProjectCommand)
        {
            await Mediator.Send(attachProjectCommand);

            return NoContent();
        }

        [HttpPost]
        [Route("createDocuments")]
        public async Task<IActionResult> PostCreateDocuments(CreateDocumentCommand createDocumentCommand)
        {
            await Mediator.Send(createDocumentCommand);

            return NoContent();
        }

        [HttpPost]
        [Route("createProjectFeedback")]
        public async Task<IActionResult> PostCreateProjectFeedback(CreateProjectPaymentCommand createProjectFeedback)
        {
            await Mediator.Send(createProjectFeedback);

            return NoContent();
        }
    }
}
