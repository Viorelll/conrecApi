using System;
using System.Collections.Generic;

namespace Conrec.Domain.Entities
{
    public class Project
    {
        public Project()
        {
            Schedules = new HashSet<Schedule>();
            Rates = new HashSet<Rate>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int TotalTimeWork { get; set; } // investigate if needed
        public string Requires { get; set; }
        public string Website { get; set; }
        public DateTimeOffset FilledBy { get; set; }
        public DateTimeOffset PostedOn { get; set; }
        public DateTimeOffset StartedDate { get; set; }
        public DateTimeOffset CompletedDate { get; set; }
        public DateTimeOffset ExpectedDate { get; set; }

        #region Links
        public int UserId { get; set; }
        public Employee Employee { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public int PerformanceId { get; set; }
        public Performance Performance { get; set; }
        public ICollection<Schedule> Schedules { get; private set; }
        public ICollection<Rate> Rates { get; private set; }

        #endregion
    }
}