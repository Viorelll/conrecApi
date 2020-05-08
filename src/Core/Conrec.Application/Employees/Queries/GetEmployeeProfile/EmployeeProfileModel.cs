using System;
using System.Linq;
using System.Linq.Expressions;
using Conrec.Domain.Entities;

namespace Conrec.Application.Employees.Queries.GetEmployeeProfile
{
    public class EmployeeProfileModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CountryName { get; set; }
        public string RegionName { get; set; }
        public string PhoneNumber { get; set; }
        public string SkillName { get; set; }
        public string NINO { get; set; }
        public int Experience { get; set; }
        public DateTimeOffset RegisterOn { get; set; }
        public bool AvailabilWorkImmediate { get; set; }
        public DateTimeOffset AvailabilStartsOn { get; set; }
        public int TeamId { get; set; }

        public static Expression<Func<Employee, EmployeeProfileModel>> Projection
        {
            get
            {
                return employee => new EmployeeProfileModel
                {
                    Id = employee.Id,
                    FirstName = employee.User.FirstName,
                    LastName = employee.User.LastName,
                    CountryName = employee.Country.Name,
                    RegionName = employee.User.Region.Name,
                    PhoneNumber = string.Join(",", employee.User.Contacts.Select(x => x.PhoneNumber)),
                    SkillName = employee.Skill.Name,
                    NINO = employee.NINO,
                    Experience = employee.Experience,
                    RegisterOn = employee.User.RegisterDate,
                    AvailabilWorkImmediate = employee.AvailabilWorkImmediate,
                    AvailabilStartsOn = employee.AvailabilStartsOn,
                    TeamId = employee != null ? employee.Team.Id : 0
                };
            }
        }

        public static EmployeeProfileModel Create(Employee employee)
        {
            return Projection.Compile().Invoke(employee);
        }
    }
}
