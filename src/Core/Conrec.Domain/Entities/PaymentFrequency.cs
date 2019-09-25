namespace Conrec.Domain.Entities
{
    public class PaymentFrequency : RefType
    {
        #region Links
        public virtual Payment Payment { get; set; }
        #endregion
    }
}