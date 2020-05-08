using Conrec.Application.Models;
using Conrec.Domain.Entities;
using Conrec.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Conrec.Application.Employees.Commands.CreateTeam
{
    public class CreateTeamCommandHandler : IRequestHandler<CreateTeamCommand, Unit>
    {
        private readonly ConrecDbContext _context;

        public CreateTeamCommandHandler(ConrecDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(CreateTeamCommand request, CancellationToken cancellationToken)
        {
            var employee = await _context.Employee.FindAsync(request.EmployeeId);

            if (employee == null)
            {
                throw new Exception(nameof(Employer) + request.EmployeeId);
            }

            if (request.Team == null)
            {
                throw new Exception(nameof(Team) + request.EmployeeId);
            }

            var team = new Team
            {
                LeaderId = employee.Id,
                SalaryPaymentId = request.Team.SalaryPaymentId
            };

            employee.Team = team;

            // save team
             _context.Team.Add(team);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
