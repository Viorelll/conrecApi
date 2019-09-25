using MediatR;
using Conrec.Application.Models;

namespace Conrec.Application.User.Queries.GetUserValidation
{
    public class UserValidatorQuery : IRequest<UserValidatorModel>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
