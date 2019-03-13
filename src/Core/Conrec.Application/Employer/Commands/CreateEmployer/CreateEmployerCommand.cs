using Conrec.Domain.Entities;
using MediatR;

namespace Conrec.Application.Employees.Commands.CreateEmployer
{
    public class CreateEmployerCommand : IRequest
    {
        public User User { get; set; }
        public int JobRoleId { get; set; }
        public Company Company { get; set; }
    }
}
