using MediatR;
using Conrec.Application.Models;

namespace Conrec.Application.User.Queries.GetUserDetail
{
    public class GetUserDetailQuery : IRequest<UserDetailModel>
    {
        public int Id { get; set; }
    }
}
