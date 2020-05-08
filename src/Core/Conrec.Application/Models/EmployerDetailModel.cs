using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Conrec.Application.Models
{
    using Conrec.Domain.Entities;
    public class EmployerDetailModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTimeOffset? RegisterDate { get; set; }
        public CreateCompanyModel Company { get; set; }
        public JobRoleModel JobRole { get; set; }
        public UserRoleModel UserRole { get; set; }
        public RegionModel Region { get; set; }
        public ICollection<ContactModel> Contacts { get; set; } = new List<ContactModel>();
        public ICollection<BankModel> Banks { get; set; } = new List<BankModel>();
        public ICollection<NotificationModel> Notfications { get; set; } = new List<NotificationModel>();

        public static Expression<Func<Employer, EmployerDetailModel>> Projection
        {
            get
            {
                return employer => new EmployerDetailModel
                {
                    Id = employer.Id,
                    JobRole = new JobRoleModel
                    {
                        Id = employer.JobRole.Id,
                        Name = employer.JobRole.Name,
                        Description = employer.JobRole.Description
                    },
                    FirstName = employer.User.FirstName,
                    LastName = employer.User.LastName,
                    Email = employer.User.Email,
                    RegisterDate = employer.User.RegisterDate,
                    Company = new CreateCompanyModel
                    {
                        Name = employer.Company.Name,
                        Reference = employer.Company.Reference,
                        Projects = employer.Company.Projects.Select(x => new CreateProjectModel
                                    {
                                        Name = x.Name,
                                        CompletedDate = x.CompletedDate,
                                        ExpectedDate = x.ExpectedDate,
                                        FilledBy = x.FilledBy,
                                        PostedOn = x.PostedOn,
                                        Requires = x.Requires,
                                        StartedDate = x.StartedDate,
                                        Website = x.Website
                                    }).ToList()
                    },
                    Contacts = employer.User.Contacts.Select(x => new ContactModel
                    {
                        PhoneNumber = x.PhoneNumber
                    }).ToList(),
                    UserRole = new UserRoleModel
                    {
                        Id = employer.User.UserRole.Id,
                        Name = employer.User.UserRole.Name,
                        Description = employer.User.UserRole.Description
                    },
                    Region = new RegionModel
                    {
                        Name = employer.User.Region.Name,
                        PostCode = employer.User.Region.PostCode
                    },
                    Banks = employer.User.Banks.Select(x => new BankModel
                    {
                        Name = x.Name,
                        ShortCode = x.ShortCode
                    }).ToList(),
                    Notfications = employer.User.Notifications.Select(x => new NotificationModel
                    {
                        DateOn = x.DateOn
                    }).ToList(),
                };
            }
        }

        public static EmployerDetailModel Create(Employer employer)
        {
            return Projection.Compile().Invoke(employer);
        }
    }
}
