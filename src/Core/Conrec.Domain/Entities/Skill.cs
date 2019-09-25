namespace Conrec.Domain.Entities
{
    public class Skill : RefType
    {
        #region Links
        public virtual Employee Employee { get; set; }
        #endregion
    }
}