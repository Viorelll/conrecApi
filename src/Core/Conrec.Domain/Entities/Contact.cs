namespace Conrec.Domain.Entities
{
    public class Contact
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }

        #region Links
        public virtual User User { get; set; }
        public int UserId { get; set; }
        #endregion
    }
}