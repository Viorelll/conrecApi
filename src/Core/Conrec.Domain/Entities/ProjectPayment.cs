namespace Conrec.Domain.Entities
{
    public class ProjectPayment
    {
        public int Id { get; set; }

        #region Links
        public int? ProjectId { get; set; }
        public int? PaymentId { get; set; }
        public virtual Payment Payment { get; set; }
        public virtual Project Project { get; set; }
        #endregion
    }
}
