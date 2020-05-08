using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Conrec.Domain.Entities;
using Conrec.Persistence;

namespace Conrec.Application.Employees.Queries.GetEmployeeProfile
{
    public class GetAttachmentsAndAdditionalInfoQueryHandler : IRequestHandler<GetEmployeeProfileQuery, EmployeeProfileModel>
    {
        private readonly ConrecDbContext _context;

        public GetAttachmentsAndAdditionalInfoQueryHandler(ConrecDbContext context)
        {
            _context = context;
        }

        public async Task<EmployeeProfileModel> Handle(GetEmployeeProfileQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Employee
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new Exception(nameof(Employee) + request.Id);
            }

            var result = EmployeeProfileModel.Create(entity);

            return result;
        }
    }
}
