using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Conrec.Domain.Entities;
using Conrec.Persistence;

namespace Conrec.Application.Employees.Queries.GetEmployeeDetail
{
    public class GetEmployeeDetailQueryHandler : IRequestHandler<GetEmployeeDetailQuery, EmployeeDetailModel>
    {
        private readonly ConrecDbContext _context;

        public GetEmployeeDetailQueryHandler(ConrecDbContext context)
        {
            _context = context;
        }

        public async Task<EmployeeDetailModel> Handle(GetEmployeeDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Employee
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new Exception(nameof(Employee) + request.Id);
            }

            return EmployeeDetailModel.Create(entity);
        }
    }
}
