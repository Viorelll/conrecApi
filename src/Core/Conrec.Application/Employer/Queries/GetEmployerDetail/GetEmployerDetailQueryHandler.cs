using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Conrec.Domain.Entities;
using Conrec.Persistence;

namespace Conrec.Application.Employees.Queries.GetEmployerDetail
{
    public class GetEmployerDetailQueryHandler : IRequestHandler<GetEmployerDetailQuery, EmployerDetailModel>
    {
        private readonly ConrecDbContext _context;

        public GetEmployerDetailQueryHandler(ConrecDbContext context)
        {
            _context = context;
        }

        public async Task<EmployerDetailModel> Handle(GetEmployerDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Employer
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new Exception(nameof(Employee) + request.Id);
            }

            return EmployerDetailModel.Create(entity);
        }
    }
}
