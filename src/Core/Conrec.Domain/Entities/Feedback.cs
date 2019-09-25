namespace Conrec.Domain.Entities
{
    public class Feedback
    {
        public int Id { get; set; }
        public int SpecificationClarity { get; set; }
        public int Communication { get; set; }
        public int PaymentPromptness { get; set; }
        public int Professionalism { get; set; }
        public int WorkAgain { get; set; }
        public string Comment { get; set; }

        #region Links
        public int? ProjectEmployeeId { get; set; }
        public virtual ProjectEmployee ProjectEmployee { get; set; }
        #endregion
    }
}
