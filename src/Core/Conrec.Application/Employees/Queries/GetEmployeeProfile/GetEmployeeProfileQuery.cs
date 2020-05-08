using MediatR;

namespace Conrec.Application.Employees.Queries.GetEmployeeProfile
{
    public class GetEmployeeProfileQuery : IRequest<EmployeeProfileModel>
    {
        public int Id { get; set; }
    }
}
