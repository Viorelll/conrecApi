namespace Conrec.Domain.Entities
{
    public class Employer
    {
        public int Id { get; set; }
        #region Links
        public int UserId { get; set; }
        public User User { get; set; }
        public int JobRoleId { get; set; }
        public JobRole JobRole { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        #endregion
    }
}
