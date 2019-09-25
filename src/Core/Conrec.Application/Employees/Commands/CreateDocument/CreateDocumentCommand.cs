using System.Collections.Generic;
using MediatR;
using Conrec.Application.Models;

namespace Conrec.Application.Employees.Commands.CreateDocument
{
    public class CreateDocumentCommand : IRequest
    {
        public int EmployeeId { get; set; }
        public ICollection<DocumentModel> Documents { get; set; }
    }
}
