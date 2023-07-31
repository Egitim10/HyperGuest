using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperGuests.ModelResponses
{
    public class RatePlanInfo
    {
        public bool Virtual { get; set; }
        public List<Contract> Contracts { get; set; } = new();
        public string OriginalRatePlanCode { get; set; } = default!;
        public bool IsPromotion { get; set; }
        public bool IsPackageRate { get; set; }
        public bool IsPrivate { get; set; }
    }
}
