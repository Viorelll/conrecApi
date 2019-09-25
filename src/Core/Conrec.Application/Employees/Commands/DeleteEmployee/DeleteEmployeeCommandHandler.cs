using Conrec.Domain.Entities;
using Conrec.Persistence;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Conrec.Application.Employees.Commands.DeleteEmployee
{
    public class DeleteEmployeeCommandHandler : IRequest
    {
        private readonly ConrecDbContext _context;

        public DeleteEmployeeCommandHandler(ConrecDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Employee
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new Exception(nameof(Employee));
            }

            var hasProjects = _context.Project.Any(o => o.UserId == entity.Id);
            if (hasProjects)
            {
                throw new Exception("There are existing projects associated with this Employee.");
            }

            var hasDocuments = _context.Document.Any(o => o.UserId == entity.Id);
            if (hasDocuments)
            {
                throw new Exception("There are existing documents associated with this Employee.");
            }

            _context.Employee.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
