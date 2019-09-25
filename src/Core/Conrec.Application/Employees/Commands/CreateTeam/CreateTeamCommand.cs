using Conrec.Application.Models;
using MediatR;
namespace Conrec.Application.Employees.Commands.CreateTeam
{
    public class CreateTeamCommand : IRequest
    {
        public int EmployeeId { get; set; }
        public TeamDetailModel Team { get; set; }
    }
}
