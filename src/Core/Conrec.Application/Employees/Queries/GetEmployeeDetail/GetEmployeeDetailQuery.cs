using MediatR;

namespace Conrec.Application.Employees.Queries.GetEmployeeDetail
{
    public class GetEmployeeDetailQuery : IRequest<EmployeeDetailModel>
    {
        public int Id { get; set; }
    }
}
