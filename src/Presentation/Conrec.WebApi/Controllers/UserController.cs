using System.Collections.Generic;
using System.Threading.Tasks;
using Conrec.Application.Employees.Queries.GetUserDetail;
using Microsoft.AspNetCore.Mvc;

namespace Conrec.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        // GET: api/User
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "GetUser")]
        public async Task<ActionResult<UserDetailModel>> Get(int id)
        {
            return Json(await Mediator.Send(new GetUserDetailQuery { Id = id }));
        }
    }
}
