using Conrec.Domain.Entities;
using Conrec.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Conrec.Application.Employees.Commands.CreateEmployer
{
    public class CreateEmployerCommandHandler : IRequestHandler<CreateEmployerCommand, Unit>
    {
        private readonly ConrecDbContext _context;
        //private readonly IMediator _mediator;

        public CreateEmployerCommandHandler(
            ConrecDbContext context,
            IMediator mediator)
        {
            _context = context;
            // _mediator = mediator;
        }

        public async Task<Unit> Handle(CreateEmployerCommand request, CancellationToken cancellationToken)
        {
            var entity = new Employer
            {
                User = request.User,
                JobRoleId = request.JobRoleId,
                Company = request.Company
            };

            _context.Employer.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId });

            return Unit.Value;
        }
    }
}
