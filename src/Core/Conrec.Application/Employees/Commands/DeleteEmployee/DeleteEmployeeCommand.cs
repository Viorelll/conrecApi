using MediatR;

namespace Conrec.Application.Employees.Commands.DeleteEmployee
{
    public class DeleteEmployeeCommand : IRequest
    {
        public int Id { get; set; }
    }
}
