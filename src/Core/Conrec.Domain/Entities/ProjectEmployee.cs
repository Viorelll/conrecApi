using System.Collections.Generic;

namespace Conrec.Domain.Entities
{
    public class ProjectEmployee
    {
        public ProjectEmployee()
        {
            ProjectReports = new HashSet<Report>();
        }
        public int Id { get; set; }

        public bool IsActive { get; set; }
        public int TotalTimeWork { get; set; }

        #region Links
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
        public virtual ICollection<Report> ProjectReports { get; set; }
        public virtual Feedback ProjectFeedback { get; set; }
        public virtual ProjectEmployeePayment ProjectEmployeePayment { get; set; }

        //public int? ScheduleId { get; set; }
        public virtual ICollection<ProjectSchedule> ProjectSchedules { get; set; }
        #endregion
    }
}
