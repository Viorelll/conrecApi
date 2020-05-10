using Conrec.Domain.Entities;
using Conrec.Persistence;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Conrec.Application.Employer.Commands.CreateProject
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, Unit>
    {
        private readonly ConrecDbContext _context;

        public CreateProjectCommandHandler(ConrecDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var employer = await _context.Employer.FindAsync(request.EmployerId);

            if (employer == null)
            {
                throw new Exception(nameof(Employer) + request.EmployerId);
            }

            if (employer.Company == null || employer.CompanyId == null)
            {
                throw new Exception(nameof(Company) + request.EmployerId);
            }

            var project = new Project
            {
                Name = request.Project?.Name,
                Requires = request.Project?.Requires,
                Website = request.Project?.Website,
                FilledBy = request.Project.FilledBy,
                PostedOn = request.Project.PostedOn,
                StartedDate = request.Project.StartedDate,
                CompletedDate = request.Project.CompletedDate,
                ExpectedDate = request.Project.ExpectedDate,
            };

            var requestSchedule = request.Project.Schedule;

            var schedule = new Schedule
            {
                IsBreakPaid = requestSchedule.IsBreakPaid,
                BreakStart = DateTime.Today.AddHours(requestSchedule.BreakStart),
                BreakEnd = DateTime.Today.AddHours(requestSchedule.BreakEnd),
                DayStart = DateTime.Today.AddHours(requestSchedule.DayStart),
                DayEnd = DateTime.Today.AddHours(requestSchedule.DayEnd),
                EstimatedWorkedHoursWeekly = requestSchedule.TotalHoursWorked,
                WorkDay = _context.WorkDay.Find(requestSchedule.WorkDayId)
            };

            var projectSchedule = new ProjectSchedule
            {
                EffectiveFrom = DateTime.Now,
                EffectiveTo = DateTime.Now.AddMonths(1),
                Schedule = schedule
            };

            project.ProjectSchedules.Add(projectSchedule);
            project.UserId = employer.Id;
            project.CompanyId = employer.CompanyId.Value;

            // save project
             _context.Project.Add(project);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
