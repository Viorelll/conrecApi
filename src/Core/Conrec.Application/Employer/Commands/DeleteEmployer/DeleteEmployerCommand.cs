using MediatR;

namespace Conrec.Application.Employees.Commands.DeleteEmployer
{
    public class DeleteEmployerCommand : IRequest
    {
        public int Id { get; set; }
    }
}
