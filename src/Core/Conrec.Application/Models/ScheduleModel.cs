using System;

namespace Conrec.Application.Models
{
    public class ScheduleModel
    {
        public bool IsBreakPaid { get; set; }
        public double TotalHoursWorked { get; set; }
        public DateTimeOffset BreakStart { get; set; }
        public DateTimeOffset BreakEnd { get; set; }
        public DateTimeOffset DayStart { get; set; }
        public DateTimeOffset DayEnd { get; set; }
        public int WorkDayId { get; set; }
    }
}