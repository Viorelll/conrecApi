using System;
using System.Collections.Generic;

namespace Conrec.Domain.Entities
{
    public class User
    {
        public User()
        {
            Banks = new HashSet<Bank>();
            Contacts = new HashSet<Contact>();
            Notifications = new HashSet<Notification>();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTimeOffset? RegisterDate { get; set; }

        #region Links
        public Employee Employee { get; set; }
        public Employer Employer { get; set; }
        public int UserRolesId { get; set; }
        public UserRole UserRole { get; set; }
        public int RegionId { get; set; }
        public Region Region { get; set; }
        public ICollection<Contact> Contacts { get; private set; }
        public ICollection<Bank> Banks { get; private set; }
        public ICollection<Notification> Notifications { get; private set; }
        #endregion
    }
}