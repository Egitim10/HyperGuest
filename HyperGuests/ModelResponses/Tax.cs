using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperGuests.ModelResponses
{
    public class Tax
    {
        public string Description { get; set; } = default!;
        public double Amount { get; set; }
        public string Currency { get; set; } = default!;
        public string Relation { get; set; } = default!;
    }
}
