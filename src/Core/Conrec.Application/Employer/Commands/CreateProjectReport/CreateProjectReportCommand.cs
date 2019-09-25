using MediatR;
namespace Conrec.Application.Employer.Commands.CreateProjectReport
{
    public class CreateProjectReportCommand : IRequest
    {
        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }
        public CreateProjectReportModel PerformanceReport { get; set; }
    }
}
