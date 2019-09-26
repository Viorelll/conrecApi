using Conrec.Application.Models;
using MediatR;
namespace Conrec.Application.Employer.Commands.CreateProject
{
    public class CreateProjectCommand : IRequest
    {
        public int EmployerId { get; set; }
        public CreateProjectModel Project { get; set; }
    }
}
