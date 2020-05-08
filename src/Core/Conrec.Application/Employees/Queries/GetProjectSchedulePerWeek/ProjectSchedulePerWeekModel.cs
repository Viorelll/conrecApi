using Conrec.Application.Models;
using Conrec.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Conrec.Application.Employees.Queries.GetProjectSchedulePerWeek
{
    public class ProjectSchedulePerWeekModel
    {
        public bool IsBreakPaid { get; set; }
        public DateTimeOffset BreakStart { get; set; }
        public DateTimeOffset BreakEnd { get; set; }
        public DateTimeOffset DayStart { get; set; }
        public DateTimeOffset DayEnd { get; set; }
        public double TotalHoursWorked { get; set; }

        public static Expression<Func<ProjectEmployee, ProjectSchedulePerWeekModel>> Projection
        {
            get
            {
                return projectEmployee => projectEmployee.ProjectSchedules.Select(x => new ProjectSchedulePerWeekModel
                {
                    IsBreakPaid = x.Is,
                    Name = x.Project.Name,
                    Requires = x.Project.Requires,
                    Website = x.Project.Website,
                    FilledBy = x.Project.FilledBy,
                    PostedOn = x.Project.PostedOn,
                    StartedDate = x.Project.StartedDate,
                    CompletedDate = x.Project.CompletedDate,
                    ExpectedDate = x.Project.ExpectedDate,
                    Feedback = x.ProjectFeedback.Comment
                });
           
            }
        }

        public static ProjectSchedulePerWeekModel Create(ProjectEmployee projectEmployee)
        {
            return Projection.Compile().Invoke(projectEmployee);
        }
    }
}
