using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Conrec.Domain.Entities;
using Conrec.Persistence;
using System.Linq;

namespace Conrec.Application.Employees.Queries.GetProjectDetails
{
    public class GGetProjectDetailsQueryHandler : IRequestHandler<GetProjectDetailsQuery, ProjectDetailsModel>
    {
        private readonly ConrecDbContext _context;

        public GGetProjectDetailsQueryHandler(ConrecDbContext context)
        {
            _context = context;
        }

        public async Task<ProjectDetailsModel> Handle(GetProjectDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Employee
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new Exception(nameof(Employee) + request.Id);
            }

            var projectEmployee = entity.ProjectEmployees
                .Where(x => x.IsActive)
                .FirstOrDefault();

            var result = ProjectDetailsModel.Create(projectEmployee);

            return result;
        }
    }
}
