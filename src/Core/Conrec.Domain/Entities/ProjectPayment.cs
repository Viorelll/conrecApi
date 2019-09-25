using System;
using System.Collections.Generic;

namespace Conrec.Domain.Entities
{
    public class ProjectPayment
    {
        public int Id { get; set; }

        #region Links
        public int? ProjectId { get; set; }
        public int? PaymentId { get; set; }
        public int? ProjectEmployeeId { get; set; }
        public int? ProjectPaymentId { get; set; }
        public virtual Payment Payment { get; set; }
        public virtual Project Project { get; set; }
        public virtual ProjectEmployee ProjectEmployee { get; set; }
        #endregion
    }
}
