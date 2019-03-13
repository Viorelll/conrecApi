namespace Conrec.Domain.Entities
{
    public class JobRole : RefType
    {
        #region Links
        public Employer Employer { get; set; }
        #endregion
    }
}