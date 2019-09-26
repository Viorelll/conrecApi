using MediatR;
using Conrec.Application.Models;
using System;

namespace Conrec.Application.Employer.Commands.CreateProjectPayment
{
    public class CreateProjectPaymentCommand : IRequest
    {
        public int ProjectId { get; set; }
        public PaymentModel Payment { get; set; }
    }
}
