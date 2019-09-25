using System;
using System.Collections.Generic;

namespace Conrec.Domain.Entities
{
    public class Schedule
    {
        public int Id { get; set; }
        public bool IsBreakPaid { get; set; }
        public DateTimeOffset BreakStart { get; set; }
        public DateTimeOffset BreakEnd { get; set; }
        public DateTimeOffset DayStart { get; set; }
        public DateTimeOffset DayEnd { get; set; }
        public double TotalHoursWorked { get; set; }

        #region Links
        public int WorkDayId { get; set; }
        public virtual WorkDay WorkDay { get; set; }
        public virtual ICollection<ProjectSchedule> ProjectSchedules { get; set; }

        #endregion
    }
}