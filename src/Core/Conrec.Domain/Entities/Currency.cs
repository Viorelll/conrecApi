namespace Conrec.Domain.Entities
{
    public class Currency : RefType
    {
        #region Links
        public Payment Payment { get; set; }
        #endregion
    }
}