namespace Conrec.Domain.Entities
{
    public class SalaryPayment : RefType
    {
        #region Links
        public Team Team { get; set; }
        #endregion
    }
}