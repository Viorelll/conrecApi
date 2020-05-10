using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Conrec.Domain.Entities;
using Conrec.Persistence;
using System.Linq;
using System.Collections.Generic;

namespace Conrec.Application.Employees.Queries.GetProjectSchedulePerWeek
{
    public class GetProjectSchedulePerWeekQueryHandler : IRequestHandler<GetProjectSchedulePerWeekQuery, List<ProjectSchedulePerWeekModel>>
    {
        private readonly ConrecDbContext _context;

        public GetProjectSchedulePerWeekQueryHandler(ConrecDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProjectSchedulePerWeekModel>> Handle(GetProjectSchedulePerWeekQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Employee
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new Exception(nameof(Employee) + request.Id);
            }

            var activeProjectEmployee = entity.ProjectEmployees.Where(x => x.IsActive).FirstOrDefault();

            var result = ProjectSchedulePerWeekModel.Create(activeProjectEmployee);

            return result;
        }
    }
}
