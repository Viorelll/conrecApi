using System.Collections.Generic;

namespace Conrec.Application.Employer.Commands.ConfirmProjectPayment
{
    public class ModifiedEmployeeModel
    {
        public int EmployeeId { get; set; }
        public ICollection<DateModel> Dates { get; set; }
    }
}