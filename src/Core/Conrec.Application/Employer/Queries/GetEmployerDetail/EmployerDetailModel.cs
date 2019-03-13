using Conrec.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace Conrec.Application.Employees.Queries.GetEmployerDetail
{
    public class EmployerDetailModel
    {
        public int Id { get; set; }
        public int JobRoleId { get; set; }
        public Company Company { get; set; }

        public static Expression<Func<Employer, EmployerDetailModel>> Projection
        {
            get
            {
                return employer => new EmployerDetailModel
                {
                    Id = employer.Id,
                    JobRoleId = employer.JobRoleId,
                    Company = employer.Company
                };
            }
        }

        public static EmployerDetailModel Create(Employer employer)
        {
            return Projection.Compile().Invoke(employer);
        }
    }
}
