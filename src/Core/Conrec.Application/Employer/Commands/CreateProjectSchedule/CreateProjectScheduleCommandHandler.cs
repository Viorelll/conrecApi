﻿using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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
                .Where(x => x.ProjectId == request.ProjectId)
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

            var projectSchedule = new ProjectSchedule
            {
                EffectiveFrom = request.EffectiveFrom,
                EffectiveTo = request.EffectiveTo,
                Schedule = schedule,
                ProjectId = projectEmployee.ProjectId
            };

            // save new project schedule for employee
            _context.ProjectSchedule.Add(projectSchedule);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
