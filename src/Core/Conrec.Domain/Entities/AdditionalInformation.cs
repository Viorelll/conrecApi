namespace Conrec.Domain.Entities
{
    public class AdditionalInformation
    {
        public int Id { get; set; }
        public int WillingMiles { get; set; }
        public string Details { get; set; }
        public bool HasOwnCar { get; set; }
        public bool HasRequiredPPE { get; set; }

        #region Links
        public Employee Employee { get; set; }
        #endregion
    }
}