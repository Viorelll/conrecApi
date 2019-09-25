using Conrec.Domain.Entities;
using Conrec.Persistence;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Conrec.Application.Employees.Commands.CreateProjectFeedback
{
    public class CreateProjectFeedbackCommandHandler : IRequestHandler<CreateProjectFeedbackCommand, Unit>
    {
        private readonly ConrecDbContext _context;

        public CreateProjectFeedbackCommandHandler(ConrecDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(CreateProjectFeedbackCommand request, CancellationToken cancellationToken)
        {
            var employee = await _context.Employee.FindAsync(request.EmployeeId);

            if (employee == null)
            {
                throw new Exception(nameof(Employee) + request.EmployeeId);
            }

            if (request.ProjectFeedback == null)
            {
                throw new Exception(nameof(CreateProjectFeedbackCommand) + request.EmployeeId);
            }

            var projectFeedback = new Feedback
            {
                SpecificationClarity = request.ProjectFeedback.SpecificationClarity,
                Communication = request.ProjectFeedback.Communication,
                PaymentPromptness = request.ProjectFeedback.PaymentPromptness,
                Professionalism = request.ProjectFeedback.Professionalism,
                WorkAgain = request.ProjectFeedback.WorkAgain,
                Comment = request.ProjectFeedback.Comment
            };

            var projectEmployee = employee.ProjectEmployees
                .Where(x => x.ProjectId == request.ProjectId)
                .FirstOrDefault();

            projectEmployee.ProjectFeedback = projectFeedback;

            // save feedback on project
             _context.Feedback.Add(projectFeedback);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
