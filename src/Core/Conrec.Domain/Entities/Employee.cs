using System;
using System.Collections.Generic;

namespace Conrec.Domain.Entities
{
    public class Employee
    {
        public Employee()
        {
            Documents = new HashSet<Document>();
            ProjectEmployees = new HashSet<ProjectEmployee>();
        }
        public int Id { get; set; }
        public string NINO { get; set; }
        public int Experience { get; set; }
        public bool AvailabilWorkImmediate { get; set; }
        public DateTimeOffset? AvailabilStartsOn { get; set; }

        #region Links
        public virtual User User { get; set; }
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
        public int SkillId { get; set; }
        public virtual Skill Skill { get; set; }
        public int? TeamId { get; set; }
        public virtual Team Team { get; set; }
        public int? AdditionalInformationId { get; set; }
        public virtual AdditionalInformation AdditionalInformation { get; set; }
        public virtual ICollection<ProjectEmployee> ProjectEmployees { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
        #endregion
    }
}
