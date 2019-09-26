using System;

namespace Conrec.Application.Models
{
    public class PaymentModel
    {
        public string AccountNumber { get; set; }
        public string ShortCode { get; set; }
        public string Subject { get; set; }
        public double Amount { get; set; }
        public double OriginalPayRate { get; set; }
        public double WorkedHours { get; set; }
        public DateTimeOffset PaymentDate { get; set; }
    }
}