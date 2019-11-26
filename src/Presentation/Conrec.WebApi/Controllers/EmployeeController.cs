using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Conrec.Application.Employees.Commands.CreateEmployee;
using Conrec.Application.Employees.Commands.DeleteEmployee;
using Conrec.Application.Employees.Commands.UpdateEmployee;
using Conrec.Application.Employees.Queries.GetEmployeeDetail;
using Conrec.Application.Employees.Commands.CreateTeam;
using Conrec.Application.Employees.Commands.AttachTeam;
using Conrec.Application.Employees.Commands.CreateDocument;
using Conrec.Application.Employees.Commands.AttachProject;
using Conrec.Application.Employees.Commands.CreateProjectFeedback;

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
        public async Task<ActionResult<EmployeeDetailModel>> Get(int id)
        {
            return Json(await Mediator.Send(new GetEmployeeDetailQuery { Id = id }));
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
