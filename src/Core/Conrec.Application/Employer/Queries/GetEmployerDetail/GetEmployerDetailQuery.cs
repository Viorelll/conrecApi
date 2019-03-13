using MediatR;

namespace Conrec.Application.Employees.Queries.GetEmployerDetail
{
    public class GetEmployerDetailQuery : IRequest<EmployerDetailModel>
    {
        public int Id { get; set; }
    }
}
