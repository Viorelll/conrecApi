using System;

namespace Conrec.Domain.Entities
{
    public class ProjectEmployeeSchedule
    {
        public int Id { get; set; }
        public DateTimeOffset EffectiveFrom { get; set; }
        public DateTimeOffset EffectiveTo { get; set; }

        #region Links
        public int? ScheduleId { get; set; }
        public int? ProjectEmployeeId { get; set; }
        public virtual Schedule Schedule { get; set; }
        public virtual ProjectEmployee ProjectEmployee { get; set; }

        #endregion
    }
}
