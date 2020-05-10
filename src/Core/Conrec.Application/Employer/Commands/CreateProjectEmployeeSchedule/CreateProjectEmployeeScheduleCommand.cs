using MediatR;
using Conrec.Application.Models;
using System;

namespace Conrec.Application.Employer.Commands.CreateProjectEmployeeSchedule
{
    public class CreateProjectEmployeeScheduleCommand : IRequest
    {
        public int ProjectId { get; set; }
        public int EmployeeId { get; set; }
        public DateTimeOffset EffectiveFrom { get; set; }
        public DateTimeOffset EffectiveTo { get; set; }
        public ScheduleModel Schedule { get; set; }
    }
}
