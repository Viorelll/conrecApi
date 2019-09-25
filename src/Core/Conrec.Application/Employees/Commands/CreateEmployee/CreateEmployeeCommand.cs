using Conrec.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;

namespace Conrec.Application.Employees.Commands.CreateEmployee
{
    using Conrec.Domain.Entities;
    public class CreateEmployeeCommand : IRequest
    {
        public string NINO { get; set; }
        public int Experience { get; set; }
        public bool AvailabilWorkImmediate { get; set; }
        public DateTimeOffset? AvailabilStartsOn { get; set; }
        public UserDetailModel User { get; set; }
        public int CountryId { get; set; }
        public int SkillId { get; set; }
        public AdditionalInformationModel AdditionalInformation { get; set; }
    }
}
