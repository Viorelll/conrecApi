using Conrec.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Conrec.Application.Employees.Queries.GetPreviousProjectsAndReviews
{
    public class PreviousProjectsAndReviewsModel
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
        public string Feedback { get; set; }

        public static Expression<Func<Employee, List<PreviousProjectsAndReviewsModel>>> Projection
        {
            get
            {
                return employee => employee.ProjectEmployees.Select(x => new PreviousProjectsAndReviewsModel
                    {
                        TotalTimeWork = x.TotalTimeWork,
                        Name = x.Project.Name,
                        Requires = x.Project.Requires,
                        Website = x.Project.Website,
                        FilledBy = x.Project.FilledBy,
                        PostedOn = x.Project.PostedOn,
                        StartedDate = x.Project.StartedDate,
                        CompletedDate = x.Project.CompletedDate,
                        ExpectedDate = x.Project.ExpectedDate,
                        Feedback = x.ProjectFeedback.Comment
                    }).ToList();
            }
        }

        public static List<PreviousProjectsAndReviewsModel> Create(Employee employee)
        {
            if (employee == null)
                throw new Exception("The employee doesn't have any active project!");

            return Projection.Compile().Invoke(employee);
        }
    }
}
