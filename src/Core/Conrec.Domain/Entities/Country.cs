namespace Conrec.Domain.Entities
{
    public class Country : RefType
    {
        #region Links
        public virtual Employee Employee { get; set; }
        #endregion
    }
}