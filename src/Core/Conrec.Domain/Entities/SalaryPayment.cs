namespace Conrec.Domain.Entities
{
    public class SalaryPayment : RefType
    {
        #region Links
        public virtual Team Team { get; set; }
        #endregion
    }
}