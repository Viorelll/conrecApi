using System;

namespace Conrec.Domain.Entities
{
    public class Notification
    {
        public int Id { get; set; }
        public DateTimeOffset DateOn { get; set; }

        #region Links
        public virtual User User { get; set; }
        public int UserId { get; set; }
        #endregion
    }
}