namespace Conrec.Domain.Entities
{
    public class JobRole : RefType
    {
        #region Links
        public virtual Employer Employer { get; set; }
        #endregion
    }
}