using System;

namespace Conrec.Application.Employer.Commands.ConfirmProjectPayment
{
    public class DateModel
    {
        public DateTimeOffset Date { get; set; }
        public int DayStart { get; set; }
        public int DayEnd { get; set; }
    }
}