using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Conrec.Domain.Entities;
using Conrec.Persistence;
using MediatR;

namespace Conrec.Application.Employer.Commands.CreateProjectEmployeePayment
{
    public class CreateProjectEmployeePaymentCommandHandler : IRequestHandler<CreateProjectEmployeePaymentCommand, Unit>
    {
        private readonly ConrecDbContext _context;

        public CreateProjectEmployeePaymentCommandHandler(ConrecDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(CreateProjectEmployeePaymentCommand request, CancellationToken cancellationToken)
        {
            var requestPayment = request.Payment;

            var adjustedPayRateCoefficient = 0.9;
            var getAdjustedPayRateCoefficient = requestPayment.OriginalPayRate * adjustedPayRateCoefficient;

            var projectEmployee =  _context.ProjectEmployee
                .Where(x => x.EmployeeId == request.EmployeeId && x.ProjectId == request.ProjectId)
                .FirstOrDefault();

            if (projectEmployee == null)
            {
                throw new Exception(nameof(ProjectEmployee) + request.EmployeeId);
            }

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
                CurrencyId = requestPayment.CurrencyId,
                PaymentFrequencyId = requestPayment.PaymentFrequencyId,
                PaymentTypeId = requestPayment.PaymentTypeId,
            };

            var projectEmployeePayment = _context.ProjectEmployeePayment
              .Where(x => x.ProjectEmployeeId == projectEmployee.Id && x.ProjectId == request.ProjectId)
              .FirstOrDefault();

            if (projectEmployeePayment == null)
            {
                projectEmployeePayment = new ProjectEmployeePayment
                {
                    ProjectEmployeeId = projectEmployee.Id,
                    ProjectId = request.ProjectId,
                    Payment = payment
                };

                // save new project payment
                _context.ProjectEmployeePayment.Add(projectEmployeePayment);
            }

            // update new project payment
            projectEmployeePayment.Payment = payment;
            _context.ProjectEmployeePayment.Update(projectEmployeePayment);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
