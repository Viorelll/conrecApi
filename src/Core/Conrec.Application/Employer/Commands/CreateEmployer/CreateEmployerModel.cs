using System;
using System.Collections.Generic;

namespace Conrec.Application.Models
{
    public class CreateEmployerModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTimeOffset? RegisterDate { get; set; }
        public CreateCompanyModel Company { get; set; }
        public JobRoleModel JobRole { get; set; }
        public UserRoleModel UserRole { get; set; }
        public RegionModel Region { get; set; }
        public ICollection<ContactModel> Contacts { get; set; } = new List<ContactModel>();

    }
}
