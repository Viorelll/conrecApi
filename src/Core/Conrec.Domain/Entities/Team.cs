using System.Collections.Generic;

namespace Conrec.Domain.Entities
{
    public class Team
    {
        public Team()
        {
            Members = new HashSet<Employee>();
        }
        public int Id { get; set; }

        #region Links
        public int LeaderId { get; set; }
        public int SalaryPaymentId { get; set; }
        public SalaryPayment SalaryPayment { get; set; }
        public ICollection<Employee> Members { get; private set; }
        #endregion
    }
}