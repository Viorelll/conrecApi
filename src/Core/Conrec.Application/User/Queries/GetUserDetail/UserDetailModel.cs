using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Conrec.Domain.Entities;

namespace Conrec.Application.Employees.Queries.GetUserDetail
{
    public class UserDetailModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTimeOffset? RegisterDate { get; set; }
        public int UserRolesId { get; set; }
        public int RegionId { get; set; }
        public ICollection<Contact> Contacts { get; private set; }
        public ICollection<Bank> Banks { get; private set; }
        public ICollection<Notification> Notifications { get; private set; }

        public static Expression<Func<User, UserDetailModel>> Projection
        {
            get
            {
                return user => new UserDetailModel
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    RegisterDate = user.RegisterDate,
                    UserRolesId = user.UserRolesId,
                    RegionId = user.RegionId,
                    Contacts = user.Contacts,
                    Banks = user.Banks,
                    Notifications = user.Notifications
                };
            }
        }

        public static UserDetailModel Create(User User)
        {
            return Projection.Compile().Invoke(User);
        }
    }
}
