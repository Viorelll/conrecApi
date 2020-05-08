using MediatR;

namespace Conrec.Application.Employees.Queries.GetProjectEmployeePerformance
{
    public class GetProjectEmployeePerformanceQuery : IRequest<ProjectEmployeePerformanceModel>
    {
        public int Id { get; set; }
    }
}
