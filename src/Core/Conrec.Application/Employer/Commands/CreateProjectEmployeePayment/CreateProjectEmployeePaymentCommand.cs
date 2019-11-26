using MediatR;
using Conrec.Application.Models;
using System;

namespace Conrec.Application.Employer.Commands.CreateProjectEmployeePayment
{
    public class CreateProjectEmployeePaymentCommand : IRequest
    {
        public int ProjectId { get; set; }
        public int EmployeeId { get; set; }
        public PaymentModel Payment { get; set; }
    }
}
