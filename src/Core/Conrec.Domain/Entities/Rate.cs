namespace Conrec.Domain.Entities
{
    public class Rate
    {
        public int Id { get; set; }
        public int Rating { get; set; }

        #region Links
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        #endregion
    }
}