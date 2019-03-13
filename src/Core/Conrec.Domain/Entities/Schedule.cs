using System;

namespace Conrec.Domain.Entities
{
    public class Schedule
    {
        public int Id { get; set; }
        public bool IsBreakPaid { get; set; }
        public double TotalHoursWorked { get; set; }
        public DateTimeOffset BreakTime { get; set; }
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset EndTime { get; set; }

        #region Links
        public int WorkDayId { get; set; }
        public WorkDay WorkDay { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        #endregion
    }
}