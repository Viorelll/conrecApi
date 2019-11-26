namespace Conrec.Application.Employees.Commands.CreateProjectFeedback
{
    public class CreateProjectPaymentModel
    {
        public int SpecificationClarity { get; set; }
        public int Communication { get; set; }
        public int PaymentPromptness { get; set; }
        public int Professionalism { get; set; }
        public int WorkAgain { get; set; }
        public string Comment { get; set; }
    }
}