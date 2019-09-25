using Conrec.Domain.Entities;
using Conrec.Persistence;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Conrec.Application.Employer.Commands.CreateProjectReport
{
    public class CreateProjectReportCommandHandler : IRequestHandler<CreateProjectReportCommand, Unit>
    {
        private readonly ConrecDbContext _context;

        public CreateProjectReportCommandHandler(ConrecDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(CreateProjectReportCommand request, CancellationToken cancellationToken)
        {
            var employee = await _context.Employee.FindAsync(request.EmployeeId);

            if (employee == null)
            {
                throw new Exception(nameof(Employee) + request.EmployeeId);
            }

            if (request.PerformanceReport == null)
            {
                throw new Exception(nameof(CreateProjectReportCommand) + request.EmployeeId);
            }

            var projectReport = new Report
            {
                Absences = request.PerformanceReport.Absences,
                IssuesNumber = request.PerformanceReport.IssuesNumber,
                IssuesPerDay = request.PerformanceReport.IssuesPerDay,
                WorkDays = request.PerformanceReport.WorkDays,
                Review = request.PerformanceReport.Review,
                Warnings = request.PerformanceReport.Warnings
            };

            var projectEmployee = employee.ProjectEmployees
                .Where(x => x.ProjectId == request.ProjectId)
                .FirstOrDefault();

            projectEmployee.ProjectReports.Add(projectReport);

            // save report on project
             _context.Report.Add(projectReport);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
