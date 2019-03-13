using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Conrec.Application.Employees.Commands.CreateEmployer;
using Conrec.Application.Employees.Commands.UpdateEmployer;
using Conrec.Application.Employees.Commands.DeleteEmployer;
using Conrec.Application.Employees.Queries.GetEmployerDetail;

namespace Conrec.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployerController : BaseController
    {
        // GET: api/Employer
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

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
            await Mediator.Send(command);

            return NoContent();
        }

        // PUT: api/Employer/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateEmployerCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteEmployerCommand { Id = id });

            return NoContent();
        }
    }
}
