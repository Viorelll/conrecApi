using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Conrec.Application.Employees.Commands.CreateEmployee;
using Conrec.Application.Employees.Commands.DeleteEmployee;
using Conrec.Application.Employees.Commands.UpdateEmployee;
using Conrec.Application.Employees.Queries.GetEmployeeDetail;

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
    }
}
