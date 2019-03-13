namespace Conrec.Domain.Entities
{
    public class WorkDay : RefType
    {
        #region Links
        public Schedule Schedule { get; set; }
        #endregion
    }
}