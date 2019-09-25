namespace Conrec.Domain.Entities
{
    public class Bank
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortCode { get; set; }

        #region Links
        public virtual User User { get; set; }
        public int UserId { get; set; }
        #endregion
    }
}