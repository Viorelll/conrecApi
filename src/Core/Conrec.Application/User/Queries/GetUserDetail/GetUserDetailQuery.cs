using MediatR;

namespace Conrec.Application.Employees.Queries.GetUserDetail
{
    public class GetUserDetailQuery : IRequest<UserDetailModel>
    {
        public int Id { get; set; }
    }
}
