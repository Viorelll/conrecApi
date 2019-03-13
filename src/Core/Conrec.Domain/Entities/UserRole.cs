namespace Conrec.Domain.Entities
{
    public class UserRole : RefType
    {
        #region Links
        public User User { get; set; }
        #endregion
    }
}