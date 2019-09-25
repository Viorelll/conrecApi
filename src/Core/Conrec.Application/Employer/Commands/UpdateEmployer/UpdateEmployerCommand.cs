using MediatR;

namespace Conrec.Application.Employees.Commands.UpdateEmployer
{
    using Conrec.Domain.Entities;
    public class UpdateEmployerCommand : IRequest
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int JobRoleId { get; set; }
        public Company Company { get; set; }
    }
}
