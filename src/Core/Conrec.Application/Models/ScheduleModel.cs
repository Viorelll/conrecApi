using System;

namespace Conrec.Application.Models
{
    public class ScheduleModel
    {
        public bool IsBreakPaid { get; set; }
        public double TotalHoursWorked { get; set; }
        public int BreakStart { get; set; }
        public int BreakEnd { get; set; }
        public int DayStart { get; set; }
        public int DayEnd { get; set; }
        public int WorkDayId { get; set; }
    }
}