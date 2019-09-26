using System.Threading;
using System.Threading.Tasks;
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

            var adjustedPayRateCoefficient = 0.9;
            var getAdjustedPayRateCoefficient = requestPayment.OriginalPayRate * adjustedPayRateCoefficient;

            var payment = new Payment
            {
                AccountNumber = requestPayment.AccountNumber,
                ShortCode = requestPayment.ShortCode,
                Subject = requestPayment.Subject,
                Amount = requestPayment.Amount,
                OriginalPayRate = requestPayment.OriginalPayRate,
                AdjustedPayRate = getAdjustedPayRateCoefficient,
                WorkedHours = requestPayment.WorkedHours,
                PaymentDate = requestPayment.PaymentDate,
            };

            var projectPayment = new ProjectPayment
            {
                ProjectId = request.ProjectId,
                Payment = payment
            };

            // save new project payment
            _context.ProjectPayment.Add(projectPayment);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
