namespace Conrec.Domain.Entities
{
    public class Employer
    {
        public int Id { get; set; }

        #region Links
        public virtual User User { get; set; }
        public int JobRoleId { get; set; }
        public virtual JobRole JobRole { get; set; }
        public int? CompanyId { get; set; }
        public virtual Company Company { get; set; }
        #endregion
    }
}
