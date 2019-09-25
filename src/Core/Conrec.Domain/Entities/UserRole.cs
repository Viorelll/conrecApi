namespace Conrec.Domain.Entities
{
    public class UserRole : RefType
    {
        #region Links
        public virtual User User { get; set; }
        #endregion
    }
}