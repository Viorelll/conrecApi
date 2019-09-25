using System;
using System.Collections.Generic;

namespace Conrec.Domain.Entities
{
    public class Project
    {
        public Project()
        {
            ProjectEmployees = new HashSet<ProjectEmployee>();
            ProjectSchedules = new HashSet<ProjectSchedule>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Requires { get; set; }
        public string Website { get; set; }
        public DateTimeOffset FilledBy { get; set; }
        public DateTimeOffset PostedOn { get; set; }
        public DateTimeOffset StartedDate { get; set; }
        public DateTimeOffset CompletedDate { get; set; }
        public DateTimeOffset ExpectedDate { get; set; }

        #region Links
        public int UserId { get; set; }
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
        public virtual ICollection<ProjectEmployee> ProjectEmployees { get; set; }
        public virtual ICollection<ProjectSchedule> ProjectSchedules { get; set; }
        public virtual ICollection<ProjectPayment> ProjectPayments { get; set; }

        #endregion
    }
}