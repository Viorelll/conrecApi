using System;

namespace Conrec.Domain.Entities
{ 
    public class Document
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public DateTimeOffset CreateDate { get; set; }

        #region Links
        public User User { get; set; }
        public int UserId { get; set; }
        #endregion
    }
}