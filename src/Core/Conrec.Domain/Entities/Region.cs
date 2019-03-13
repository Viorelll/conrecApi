namespace Conrec.Domain.Entities
{
    public class Region
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PostCode { get; set; }

        #region Links
        public User User { get; set; }
        #endregion
    }
}