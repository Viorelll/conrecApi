using Conrec.Domain.Entities;
using Conrec.Persistence;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Conrec.Application.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Unit>
    {
        private readonly ConrecDbContext _context;
        //private readonly IMediator _mediator;

        public CreateEmployeeCommandHandler(
            ConrecDbContext context,
            IMediator mediator)
        {
            _context = context;
            // _mediator = mediator;
        }

        public async Task<Unit> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var entity = new Employee
            {
                NINO = request.NINO,
                Experience = request.Experience,
                AvailabilWorkImmediate = request.AvailabilWorkImmediate,
                AvailabilStartsOn = request.AvailabilStartsOn,
                User = request.User,
                CountryId = request.CountryId,
                SkillId = request.SkillId,
                AdditionalInformation = request.AdditionalInformation,
                Documents = request.Documents,
                Projects = request.Projects
            };

            // save user
            _context.Employee.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            // attach team
            await AttachTeam(request, entity, cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId });

            return Unit.Value;
        }

        private async Task AttachTeam(CreateEmployeeCommand request, Employee entity, CancellationToken cancellationToken)
        {
            var employee = _context.Employee.Find(entity.Id);

            var team = _context.Team.Find(request.Team.Id);

            // attach existed to team
            if (team != null)
            {
                team.Members.Add(employee);
            }

            if (team == null && request.Team != null)
            {
                // create new team
                employee.Team = new Team
                {
                    SalaryPaymentId = request.Team.SalaryPaymentId,
                    LeaderId = entity.Id
                };

                // create new notification
                employee.User.Notifications.Add(new Notification
                {
                    DateOn = DateTimeOffset.Now
                });
            }

            _context.Employee.Attach(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
