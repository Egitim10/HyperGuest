using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperGuests.ModelResponses
{
    public class PriceDetails
    {
        public double Price { get; set; }
        public string Currency { get; set; } = default!;
        public List<Tax> Taxes { get; set; } = new();
    }
}
