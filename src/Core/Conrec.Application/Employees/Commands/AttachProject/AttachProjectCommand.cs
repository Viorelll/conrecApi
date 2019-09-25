using Conrec.Application.Models;
using MediatR;
namespace Conrec.Application.Employees.Commands.AttachProject
{
    public class AttachProjectCommand : IRequest
    {
        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }
        public bool IsActive { get; set; }
        public int TotalTimeWork { get; set; }
    }
}
