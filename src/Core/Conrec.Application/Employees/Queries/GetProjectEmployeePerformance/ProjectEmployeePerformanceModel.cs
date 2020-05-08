using Conrec.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Conrec.Application.Employees.Queries.GetProjectEmployeePerformance
{
    public class ProjectEmployeePerformanceModel
    {
        public double SpecificationClarity { get; set; }
        public double Communication { get; set; }
        public double PaymentPromptness { get; set; }
        public double Professionalism { get; set; }
        public double WorkAgain { get; set; }
        public string Comments { get; set; }

        public static Expression<Func<IEnumerable<ProjectEmployee>, ProjectEmployeePerformanceModel>> Projection
        {
            get
            {
                return projectsEmployee => new ProjectEmployeePerformanceModel
                {
                    SpecificationClarity = projectsEmployee.Select(x => x.ProjectFeedback.SpecificationClarity).Average(),
                    Communication = projectsEmployee.Select(x => x.ProjectFeedback.Communication).Average(),
                    PaymentPromptness = projectsEmployee.Select(x => x.ProjectFeedback.PaymentPromptness).Average(),
                    Professionalism = projectsEmployee.Select(x => x.ProjectFeedback.Professionalism).Average(),
                    WorkAgain = projectsEmployee.Select(x => x.ProjectFeedback.WorkAgain).Average(),
                    Comments = string.Join(", ", projectsEmployee.Select(x => x.ProjectFeedback.Comment))
                };
            }
        }

        public static ProjectEmployeePerformanceModel Create(IEnumerable<ProjectEmployee> projectsEmployee)
        {
            return Projection.Compile().Invoke(projectsEmployee);
        }
    }
}
