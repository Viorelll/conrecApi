namespace Conrec.Domain.Entities
{
    public class Performance
    {
        public int Id { get; set; }
        public int Absences { get; set; }
        public int IssuesNumber { get; set; }
        public int IssuesPerDay { get; set; }
        public int Warnings { get; set; }
        public int WorkDays { get; set; }
        public string Review { get; set; }

        #region Links
        public Project Project { get; set; }
        #endregion
    }
}