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
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTimeOffset RegisterDate { get; set; }

        #region Links
        public virtual Employee Employee { get; set; }
        public virtual Employer Employer { get; set; }
        public int UserRolesId { get; set; }
        public virtual UserRole UserRole { get; set; }
        public int RegionId { get; set; }
        public virtual Region Region { get; set; }
        public virtual ICollection<Contact> Contacts { get; private set; }
        public virtual ICollection<Bank> Banks { get; private set; }
        public virtual ICollection<Notification> Notifications { get; private set; }
        #endregion
    }
}