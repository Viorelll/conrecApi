using MediatR;
using System.Collections.Generic;

namespace Conrec.Application.Employer.Commands.ConfirmProjectPayment
{
    public class ConfirmProjectPaymentCommand : IRequest
    {
        public int ProjectId { get; set; }
        public bool HasConfirmAll { get; set; }
        public ICollection<ModifiedEmployeeModel> ModifiedEmployees { get; set; }
    }
}
