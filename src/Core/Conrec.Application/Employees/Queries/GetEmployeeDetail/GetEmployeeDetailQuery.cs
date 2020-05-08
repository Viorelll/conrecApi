using MediatR;

namespace Conrec.Application.Employees.Queries.GetEmployeeDetail
{
    public class GetEmployeeDetailQuery : IRequest<EmployeeDetailsModel>
    {
        public int Id { get; set; }
    }
}
