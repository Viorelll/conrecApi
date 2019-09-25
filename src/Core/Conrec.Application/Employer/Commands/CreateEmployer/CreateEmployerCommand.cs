using MediatR;

namespace Conrec.Application.Employees.Commands.CreateEmployer
{
    using Conrec.Application.Models;
    public class CreateEmployerCommand : IRequest<int>
    {
        public CreateEmployerModel Employer { get; set; }
        public int JobRoleId { get; set; }
        public CreateCompanyModel Company { get; set; }
    }
}
