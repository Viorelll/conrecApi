namespace Conrec.Domain.Entities
{
    public class WorkDay : RefType
    {
        #region Links
        public virtual Schedule Schedule { get; set; }
        #endregion
    }
}