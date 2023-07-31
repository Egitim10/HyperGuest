using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperGuests.ModelResponses
{
    public class Payment
    {
        public string Charge { get; set; } = default!;
        public string ChargeType { get; set; } = default!;
        public PriceDetails ChargeAmount { get; set; } = default!;
    }
}
