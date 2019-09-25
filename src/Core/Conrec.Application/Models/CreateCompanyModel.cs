using System.Collections.Generic;
using Conrec.Application.Employer.Commands.CreateProject;

namespace Conrec.Application.Models
{
    public class CreateCompanyModel
    {
        public string Name { get; set; }
        public long Reference { get; set; }
        public List<CreateProjectModel> Projects { get; set; } = new List<CreateProjectModel>();
    }
}