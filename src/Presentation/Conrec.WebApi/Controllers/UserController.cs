using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Conrec.Application.Models;
using Conrec.Application.User.Queries.GetUserDetail;

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
