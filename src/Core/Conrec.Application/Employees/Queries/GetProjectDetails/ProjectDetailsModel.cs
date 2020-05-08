using System;
using System.Linq.Expressions;
using Conrec.Domain.Entities;

namespace Conrec.Application.Employees.Queries.GetProjectDetails
{
    public class ProjectDetailsModel
    {
        public int TotalTimeWork { get; set; }
        public string Name { get; set; }
        public string Requires { get; set; }
        public string Website { get; set; }
        public DateTimeOffset FilledBy { get; set; }
        public DateTimeOffset PostedOn { get; set; }
        public DateTimeOffset StartedDate { get; set; }
        public DateTimeOffset CompletedDate { get; set; }
        public DateTimeOffset ExpectedDate { get; set; }

        public static Expression<Func<ProjectEmployee, ProjectDetailsModel>> Projection
        {
            get
            {
                return projectEmployee => new ProjectDetailsModel
                {
                    TotalTimeWork = projectEmployee.TotalTimeWork,
                    Name = projectEmployee.Project.Name,
                    Requires = projectEmployee.Project.Requires,
                    Website = projectEmployee.Project.Website,
                    FilledBy = projectEmployee.Project.FilledBy,
                    PostedOn = projectEmployee.Project.PostedOn,
                    StartedDate = projectEmployee.Project.StartedDate,
                    CompletedDate = projectEmployee.Project.CompletedDate,
                    ExpectedDate = projectEmployee.Project.ExpectedDate
                };
            }
        }

        public static ProjectDetailsModel Create(ProjectEmployee projectEmployee)
        {
            if (projectEmployee == null)
                throw new Exception("The employee doesn't have any active project!");

            return Projection.Compile().Invoke(projectEmployee);
        }
    }
}
