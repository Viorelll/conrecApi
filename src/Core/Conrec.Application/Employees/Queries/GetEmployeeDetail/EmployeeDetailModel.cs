using Conrec.Application.Models;
using Conrec.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Conrec.Application.Employees.Queries.GetEmployeeDetail
{
    public class EmployeeDetailModel
    {
        public int Id { get; set; }
        public string NINO { get; set; }
        public int Experience { get; set; }
        public bool AvailabilWorkImmediate { get; set; }
        public DateTimeOffset? AvailabilStartsOn { get; set; }
        public int CountryId { get; set; }
        public int SkillId { get; set; }
        public int? TeamId { get; set; }
        public int? AdditionalInformationId { get; set; }
        public ICollection<ProjectEmployeeModel> Projects { get; set; }
        public ICollection<Document> Documents { get; set; }

        public static Expression<Func<Employee, EmployeeDetailModel>> Projection
        {
            get
            {
                return employee => new EmployeeDetailModel
                {
                    Id = employee.Id,
                    NINO = employee.NINO,
                    Experience = employee.Experience,
                    AvailabilWorkImmediate = employee.AvailabilWorkImmediate,
                    AvailabilStartsOn = employee.AvailabilStartsOn,
                    CountryId = employee.CountryId,
                    SkillId = employee.SkillId,
                    TeamId = employee.TeamId,
                    AdditionalInformationId = employee.AdditionalInformationId,
                    Documents = employee.Documents,
                    Projects = employee.ProjectEmployees.Select(x => new ProjectEmployeeModel
                    {
                        ProjectId = x.ProjectId,
                        EmployeeId = x.EmployeeId,
                        IsActive = x.IsActive,
                        TotalTimeWork = x.TotalTimeWork
                    }).ToList()
                };
            }
        }

        public static EmployeeDetailModel Create(Employee employee)
        {
            return Projection.Compile().Invoke(employee);
        }
    }
}
