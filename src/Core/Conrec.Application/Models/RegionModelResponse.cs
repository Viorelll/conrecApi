using System.Collections.Generic;


namespace Conrec.Application.Models
{
    public class RegionModelResponse
    {
        public string latitude { get; set; }
        public string longitude { get; set; }
        public List<string> addresses { get; set; }
    }
}