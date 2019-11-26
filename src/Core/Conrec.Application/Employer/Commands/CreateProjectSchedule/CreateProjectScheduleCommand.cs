using MediatR;
using Conrec.Application.Models;
using System;

namespace Conrec.Application.Employer.Commands.CreateProjectSchedule
{
    public class CreateProjectScheduleCommand : IRequest
    {
        public int ProjectId { get; set; }
        public int EmployeeId { get; set; }
        public DateTimeOffset EffectiveFrom { get; set; }
        public DateTimeOffset EffectiveTo { get; set; }
        public ScheduleModel Schedule { get; set; }
    }
}
