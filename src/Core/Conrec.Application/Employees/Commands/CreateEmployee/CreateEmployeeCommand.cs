using Conrec.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;

namespace Conrec.Application.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommand : IRequest
    {
        public string NINO { get; set; }
        public int Experience { get; set; }
        public bool AvailabilWorkImmediate { get; set; }
        public DateTimeOffset? AvailabilStartsOn { get; set; }
        public User User { get; set; }
        public int CountryId { get; set; }
        public int SkillId { get; set; }
        public TeamModel Team { get; set; }
        public AdditionalInformation AdditionalInformation { get; set; }
        public ICollection<Project> Projects { get; set; }
        public ICollection<Document> Documents { get; set; }
    }
}
