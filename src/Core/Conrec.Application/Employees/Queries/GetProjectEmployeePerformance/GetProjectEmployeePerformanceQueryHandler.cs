using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Conrec.Domain.Entities;
using Conrec.Persistence;
using System.Linq;

namespace Conrec.Application.Employees.Queries.GetProjectEmployeePerformance
{
    public class GetProjectEmployeePerformanceQueryHandler : IRequestHandler<GetProjectEmployeePerformanceQuery, ProjectEmployeePerformanceModel>
    {
        private readonly ConrecDbContext _context;

        public GetProjectEmployeePerformanceQueryHandler(ConrecDbContext context)
        {
            _context = context;
        }

        public async Task<ProjectEmployeePerformanceModel> Handle(GetProjectEmployeePerformanceQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Employee
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new Exception(nameof(Employee) + request.Id);
            }

            var projectEmployees = entity.ProjectEmployees;

            var result = ProjectEmployeePerformanceModel.Create(projectEmployees);

            return result;
        }
    }
}
