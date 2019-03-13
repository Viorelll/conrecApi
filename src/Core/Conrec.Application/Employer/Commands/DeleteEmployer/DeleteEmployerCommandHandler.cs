using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Conrec.Domain.Entities;
using Conrec.Persistence;

namespace Conrec.Application.Employees.Commands.DeleteEmployer
{
    public class DeleteEmployerCommandHandler : IRequest
    {
        private readonly ConrecDbContext _context;

        public DeleteEmployerCommandHandler(ConrecDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteEmployerCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Employer
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new Exception(nameof(Employee));
            }

            _context.Employer.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
