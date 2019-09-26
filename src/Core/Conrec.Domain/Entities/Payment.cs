using System;

namespace Conrec.Domain.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public string ShortCode { get; set; }
        public string Subject { get; set; }
        public double Amount { get; set; }
        public double OriginalPayRate { get; set; }
        public double AdjustedPayRate { get; set; }
        public double WorkedHours { get; set; }
        public DateTimeOffset PaymentDate { get; set; }

        #region Links
        public int CurrencyId { get; set; }
        public int PaymentFrequencyId { get; set; }
        public int PaymentTypeId { get; set; }
        public virtual ProjectPayment ProjectPayment { get; set; }
        #endregion
    }
}