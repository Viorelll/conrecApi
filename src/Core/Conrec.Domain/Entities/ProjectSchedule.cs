using System;
using System.Collections.Generic;

namespace Conrec.Domain.Entities
{
    public class ProjectSchedule
    {
        public int Id { get; set; }
        public DateTimeOffset EffectiveFrom { get; set; }
        public DateTimeOffset EffectiveTo { get; set; }

        #region Links
        public int? ProjectId { get; set; }
        public int? ScheduleId { get; set; }
        public int? ProjectEmployeeId { get; set; }
        public virtual Schedule Schedule { get; set; }
        public virtual Project Project { get; set; }
        public virtual ProjectEmployee ProjectEmployee { get; set; }
        #endregion
    }
}
