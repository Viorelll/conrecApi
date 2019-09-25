namespace Conrec.Domain.Entities
{
    public class PaymentType : RefType
    {
        #region Links
        public virtual Payment Payment { get; set; }
        #endregion
    }
}