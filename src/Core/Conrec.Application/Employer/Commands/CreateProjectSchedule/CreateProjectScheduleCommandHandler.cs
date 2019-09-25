using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Conrec.Application.Employer.Commands.CreateProjectReport;
using Conrec.Domain.Entities;
using Conrec.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Conrec.Application.Employer.Commands.CreateProjectSchedule
{
    public class CreateProjectScheduleCommandHandler : IRequestHandler<CreateProjectScheduleCommand, Unit>
    {
        private readonly ConrecDbContext _context;

        public CreateProjectScheduleCommandHandler(ConrecDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(CreateProjectScheduleCommand request, CancellationToken cancellationToken)
        {
            var projectEmployee = await _context.ProjectEmployee
                .Where(x => x.ProjectId == request.ProjectId && x.EmployeeId == request.EmployeeId)
                .SingleOrDefaultAsync();

            if (projectEmployee == null)
            {
                throw new Exception(nameof(ProjectEmployee) + request.EmployeeId);
            }

            var requestSchedule = request.Schedule;

            var schedule = new Schedule
            {
                IsBreakPaid = requestSchedule.IsBreakPaid,
                BreakStart = requestSchedule.BreakStart,
                BreakEnd = requestSchedule.BreakEnd,
                DayStart = requestSchedule.DayStart,
                DayEnd = requestSchedule.DayEnd,
                TotalHoursWorked = requestSchedule.TotalHoursWorked,
                WorkDay = _context.WorkDay.Find(requestSchedule.WorkDayId)
            };

            var projectSchedule = new ProjectSchedule
            {
                EffectiveFrom = request.EffectiveFrom,
                EffectiveTo = request.EffectiveTo,
                Schedule = schedule,
                ProjectId = projectEmployee.ProjectId
            };

            projectEmployee.ProjectSchedules.Add(projectSchedule);

            // save new project schedule for employee
            _context.ProjectSchedule.Add(projectSchedule);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
