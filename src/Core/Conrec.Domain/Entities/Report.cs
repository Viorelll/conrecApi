namespace Conrec.Domain.Entities
{
    public class Report
    {
        public int Id { get; set; }
        public int Absences { get; set; }
        public int IssuesNumber { get; set; }
        public int IssuesPerDay { get; set; }
        public int Warnings { get; set; }
        public int WorkDays { get; set; }
        public string Review { get; set; }

        #region Links
        public int? ProjectEmployeeId { get; set; }
        public virtual ProjectEmployee ProjectEmployee { get; set; }
        #endregion
    }
}