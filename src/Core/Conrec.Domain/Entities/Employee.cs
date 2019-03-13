using System;
using System.Collections.Generic;

namespace Conrec.Domain.Entities
{
    public class Employee
    {
        public Employee()
        {
            Documents = new HashSet<Document>();
            Projects = new HashSet<Project>();
        }
        public int Id { get; set; }
        public string NINO { get; set; }
        public int Experience { get; set; }
        public bool AvailabilWorkImmediate { get; set; }
        public DateTimeOffset? AvailabilStartsOn { get; set; }

        #region Links
        public int UserId { get; set; }
        public User User { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
        public int? TeamId { get; set; }
        public Team Team { get; set; }
        public int? AdditionalInformationId { get; set; }
        public AdditionalInformation AdditionalInformation { get; set; }
        public ICollection<Project> Projects { get; set; }
        public ICollection<Document> Documents { get; set; }
        #endregion
    }
}
