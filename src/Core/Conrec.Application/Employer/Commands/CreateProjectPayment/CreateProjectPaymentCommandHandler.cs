using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Conrec.Application.Models;
using Conrec.Domain.Entities;
using Conrec.Persistence;
using MediatR;

namespace Conrec.Application.Employer.Commands.CreateProjectPayment
{
    public class CreateProjectPaymentCommandHandler : IRequestHandler<CreateProjectPaymentCommand, Unit>
    {
        private readonly ConrecDbContext _context;

        public CreateProjectPaymentCommandHandler(ConrecDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(CreateProjectPaymentCommand request, CancellationToken cancellationToken)
        {
            var requestPayment = request.Payment;

            var projectPayment = _context.ProjectPayment.Where(x => x.ProjectId == request.ProjectId).FirstOrDefault();

            if (projectPayment == null)
            {
                CreateProjectPayment(request, requestPayment);
            }
            else
            {
                UpdateProjectPayment(requestPayment, projectPayment);
            }

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        private void UpdateProjectPayment(PaymentModel requestPayment, ProjectPayment projectPayment)
        {
            var existPayment = projectPayment.Payment;
            if (existPayment != null)
            {
                existPayment.AccountNumber = requestPayment.AccountNumber;
                existPayment.ShortCode = requestPayment.ShortCode;
                existPayment.Subject = requestPayment.Subject;
                existPayment.Amount = requestPayment.Amount;
                existPayment.OriginalPayRate = requestPayment.OriginalPayRate;
                existPayment.WorkedHours = requestPayment.WorkedHours;
                existPayment.PaymentDate = requestPayment.PaymentDate;
                existPayment.CurrencyId = requestPayment.CurrencyId;
                existPayment.PaymentFrequencyId = requestPayment.PaymentFrequencyId;
                existPayment.PaymentTypeId = requestPayment.PaymentTypeId;
                existPayment.AdjustedPayRate = requestPayment.OriginalPayRate * (1 - existPayment.CoefficientPayRate);
            }

            // update new project payment
            _context.Payment.Update(existPayment);
        }

        private ProjectPayment CreateProjectPayment(CreateProjectPaymentCommand request, PaymentModel requestPayment)
        {
            var payment = new Payment
            {
                AccountNumber = requestPayment.AccountNumber,
                ShortCode = requestPayment.ShortCode,
                Subject = requestPayment.Subject,
                Amount = requestPayment.Amount,
                OriginalPayRate = requestPayment.OriginalPayRate,
                WorkedHours = requestPayment.WorkedHours,
                PaymentDate = requestPayment.PaymentDate,
                CurrencyId = requestPayment.CurrencyId,
                PaymentFrequencyId = requestPayment.PaymentFrequencyId,
                PaymentTypeId = requestPayment.PaymentTypeId,
            };

            var defaultPayRateCoefficient = 0.1; //default coefficient is 10%
            var adjustedPayRate = requestPayment.OriginalPayRate * (1 - defaultPayRateCoefficient);
            payment.AdjustedPayRate = adjustedPayRate;
            payment.CoefficientPayRate = defaultPayRateCoefficient;

            var projectPayment = new ProjectPayment
            {
                ProjectId = request.ProjectId,
                Payment = payment
            };

            // save new project payment
            _context.ProjectPayment.Add(projectPayment);
            return projectPayment;
        }
    }
}
