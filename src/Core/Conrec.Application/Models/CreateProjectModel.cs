using Conrec.Application.Models;
using System;
using System.Collections.Generic;

namespace Conrec.Application.Models
{
    public class CreateProjectModel
    {
        public string Name { get; set; }
        public string Requires { get; set; }
        public string Website { get; set; }
        public DateTimeOffset FilledBy { get; set; }
        public DateTimeOffset PostedOn { get; set; }
        public DateTimeOffset StartedDate { get; set; }
        public DateTimeOffset CompletedDate { get; set; }
        public DateTimeOffset ExpectedDate { get; set; }
        public ScheduleModel Schedule { get; set; }
    }
}