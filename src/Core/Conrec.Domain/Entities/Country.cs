namespace Conrec.Domain.Entities
{
    public class Country : RefType
    {
        #region Links
        public Employee Employee { get; set; }
        #endregion
    }
}