using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperGuests.ModelResponses
{
    public class RatePlan
    {
        public string RatePlanCode { get; set; } = default!;
        public int RatePlanId { get; set; }
        public string RatePlanName { get; set; } = default!;
        public RatePlanInfo RatePlanInfo { get; set; } = new();
        public string Board { get; set; } = default!;
        public List<string> Remarks { get; set; }=new();
        public List<CancellationPolicy> CancellationPolicies { get; set; } = new();
        public Payment Payment { get; set; } = default!;
        public PriceDetails Prices { get; set; } = default!;
        public bool IsImmediate { get; set; } = default!;
    }
}
