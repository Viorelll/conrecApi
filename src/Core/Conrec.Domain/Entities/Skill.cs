namespace Conrec.Domain.Entities
{
    public class Skill : RefType
    {
        #region Links
        public Employee Employee { get; set; }
        #endregion
    }
}