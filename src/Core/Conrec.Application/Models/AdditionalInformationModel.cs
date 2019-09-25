using System;
using System.Collections.Generic;
using System.Text;

namespace Conrec.Application.Models
{
    public class AdditionalInformationModel
    {
        public int WillingMiles { get; set; }
        public string Details { get; set; }
        public bool HasOwnCar { get; set; }
        public bool HasRequiredPPE { get; set; }
    }
}
