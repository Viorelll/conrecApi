namespace Conrec.Domain.Entities
{
    public class ProjectPaymentEmployee
    {
        public int Id { get; set; }

        #region Links
        public int? EmployeeId { get; set; }
        public int? ProjectPaymentId { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual ProjectPayment ProjectPayment { get; set; }
        #endregion
    }
}
