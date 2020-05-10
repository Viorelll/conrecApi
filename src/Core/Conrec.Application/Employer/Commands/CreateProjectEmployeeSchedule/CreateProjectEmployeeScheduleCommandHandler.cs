using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Conrec.Domain.Entities;
using Conrec.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Conrec.Application.Employer.Commands.CreateProjectEmployeeSchedule
{
    public class CreateProjectEmployeeScheduleCommandHandler : IRequestHandler<CreateProjectEmployeeScheduleCommand, Unit>
    {
        private readonly ConrecDbContext _context;

        public CreateProjectEmployeeScheduleCommandHandler(ConrecDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(CreateProjectEmployeeScheduleCommand request, CancellationToken cancellationToken)
        {
            var projectEmployee = await _context.ProjectEmployee
                .Where(x => x.EmployeeId == request.EmployeeId && x.ProjectId == request.ProjectId)
                .SingleOrDefaultAsync();

            if (projectEmployee == null)
            {
                throw new Exception("The employee didn't have attached any project.");
            }

            var requestSchedule = request.Schedule;

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

            var projectEmployeeSchedule = new ProjectEmployeeSchedule
            {
                EffectiveFrom = request.EffectiveFrom,
                EffectiveTo = request.EffectiveTo,
                Schedule = schedule,
                ProjectEmployeeId = projectEmployee.Id
            };

            // save new project employee schedule
            _context.ProjectEmployeeSchedule.Add(projectEmployeeSchedule);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
