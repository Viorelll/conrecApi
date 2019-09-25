using Conrec.Application.Models;
using MediatR;
namespace Conrec.Application.Employees.Commands.AttachTeam
{
    public class AttachTeamCommand : IRequest
    {
        public int EmployeeId { get; set; }
        public int TeamId { get; set; }
    }
}
