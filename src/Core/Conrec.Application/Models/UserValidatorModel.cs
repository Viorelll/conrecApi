using System;
using System.Linq.Expressions;

namespace Conrec.Application.Models
{
    using Conrec.Domain.Entities;
    public class UserValidatorModel
    {
        public int Id { get; set; }

        public static Expression<Func<User, UserValidatorModel>> Projection
        {
            get
            {
                return user => new UserValidatorModel
                {
                    Id = user.UserRolesId == 1 ? user.Employer.Id : user.Employee.Id
                };
            }
        }

        public static UserValidatorModel Create(User user)
        {
            return Projection.Compile().Invoke(user);
        }
    }
}
