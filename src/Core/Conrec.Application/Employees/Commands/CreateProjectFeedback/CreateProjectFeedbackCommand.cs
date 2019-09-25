using MediatR;

namespace Conrec.Application.Employees.Commands.CreateProjectFeedback
{
    public class CreateProjectFeedbackCommand : IRequest
    {
        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }
        public CreateProjectFeedbackModel ProjectFeedback { get; set; }
    }
}
