namespace Conrec.Domain.Entities
{
    public class Currency : RefType
    {
        #region Links
        public virtual Payment Payment { get; set; }
        #endregion
    }
}