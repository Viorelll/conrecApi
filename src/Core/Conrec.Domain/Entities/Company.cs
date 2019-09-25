using System.Collections.Generic;

namespace Conrec.Domain.Entities
{
    public class Company
    {
        public Company()
        {
            Projects = new HashSet<Project>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public long Reference { get; set; }

        #region Links
        public virtual Employer Employer { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        #endregion
    }
}