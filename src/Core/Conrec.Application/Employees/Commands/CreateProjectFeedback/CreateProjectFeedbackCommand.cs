using MediatR;

namespace Conrec.Application.Employees.Commands.CreateProjectFeedback
{
    public class CreateProjectPaymentCommand : IRequest
    {
        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }
        public CreateProjectPaymentModel ProjectFeedback { get; set; }
    }
}
