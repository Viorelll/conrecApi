using Conrec.Application.Models;
using Conrec.Domain.Entities;
using Conrec.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Conrec.Application.Employees.Commands.AttachTeam
{
    public class AttachTeamCommandHandler : IRequestHandler<AttachTeamCommand, Unit>
    {
        private readonly ConrecDbContext _context;

        public AttachTeamCommandHandler(ConrecDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(AttachTeamCommand request, CancellationToken cancellationToken)
        {
            var employee = await _context.Employee.FindAsync(request.EmployeeId);

            if (employee == null)
            {
                throw new Exception(nameof(Employer) + request.EmployeeId);
            }

            if (employee.Team != null)
            {
                throw new Exception(nameof(Team) + request.EmployeeId + " is already attached");
            }

            var team = await _context.Team.FindAsync(request.TeamId);

            if (team == null)
            {
                throw new Exception(nameof(Team) + " doesn't exists");
            }

            // can't attach team if you're owner
            if (team.LeaderId == employee.Id)
            {
                throw new Exception(nameof(Team) + " you are owner on this team");
            }

            // attach team
            team.Members.Add(employee);
           _context.Team.Attach(team);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
