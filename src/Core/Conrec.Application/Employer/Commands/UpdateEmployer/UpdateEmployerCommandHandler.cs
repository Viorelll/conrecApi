using Conrec.Domain.Entities;
using Conrec.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Conrec.Application.Employees.Commands.UpdateEmployer
{
    public class UpdateEmployerCommandHandler : IRequest
    {

        private readonly ConrecDbContext _context;

        public UpdateEmployerCommandHandler(ConrecDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateEmployerCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Employer
                .SingleAsync(c => c.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new Exception(nameof(Employee) + request.Id);
            }

            entity.JobRoleId = request.JobRoleId;
            entity.Company = request.Company;

            _context.Employer.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
