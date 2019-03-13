using Conrec.Domain.Entities;
using Conrec.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Conrec.Application.Employees.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommandHandler : IRequest
    {

        private readonly ConrecDbContext _context;

        public UpdateEmployeeCommandHandler(ConrecDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Employee
                .SingleAsync(c => c.UserId == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new Exception(nameof(Employee) + request.Id);
            }

            entity.NINO = request.NINO;
            entity.Experience = request.Experience;
            entity.AvailabilWorkImmediate = request.AvailabilWorkImmediate;
            entity.AvailabilStartsOn = request.AvailabilStartsOn;
            entity.CountryId = request.CountryId;
            entity.SkillId = request.SkillId;
            entity.TeamId = request.TeamId;
            entity.AdditionalInformationId = request.AdditionalInformationId;
            entity.Documents = request.Documents;
            entity.Projects = request.Projects;

            _context.Employee.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
