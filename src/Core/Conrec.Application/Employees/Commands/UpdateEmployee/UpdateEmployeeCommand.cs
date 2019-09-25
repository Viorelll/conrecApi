using MediatR;
using System;
using System.Collections.Generic;

namespace Conrec.Application.Employees.Commands.UpdateEmployee
{
    using Conrec.Domain.Entities;
    public class UpdateEmployeeCommand : IRequest
    {
        public int Id { get; set; }
        public string NINO { get; set; }
        public int Experience { get; set; }
        public bool AvailabilWorkImmediate { get; set; }
        public DateTimeOffset? AvailabilStartsOn { get; set; }
        public User User { get; set; }
        public int CountryId { get; set; }
        public int SkillId { get; set; }
        public int? TeamId { get; set; }
        public int? AdditionalInformationId { get; set; }
        public ICollection<ProjectEmployee> ProjectEmployees { get; set; }
        public ICollection<Document> Documents { get; set; }
    }
}
