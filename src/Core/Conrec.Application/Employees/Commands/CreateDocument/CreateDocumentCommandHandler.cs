using Conrec.Application.Models;
using Conrec.Domain.Entities;
using Conrec.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Conrec.Application.Employees.Commands.CreateDocument
{
    public class CreateDocumentCommandHandler : IRequestHandler<CreateDocumentCommand, Unit>
    {
        private readonly ConrecDbContext _context;

        public CreateDocumentCommandHandler(ConrecDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(CreateDocumentCommand request, CancellationToken cancellationToken)
        {
            if (request.Documents == null) return Unit.Value;

            var employee = await _context.Employee.FindAsync(request.EmployeeId);

            if (employee == null)
            {
                throw new Exception(nameof(Employer) + request.EmployeeId);
            }

            var documents = request.Documents.Select(documentModel => new Document
            {
                Name = documentModel.Name,
                Path = documentModel.Path,
                CreateDate = documentModel.CreateDate
            }).ToList();

            employee.Documents = documents;

            // save team
             _context.Employee.Attach(employee);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
