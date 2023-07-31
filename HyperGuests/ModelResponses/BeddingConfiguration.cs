using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperGuests.ModelResponses
{
    public class BeddingConfiguration
    {
        public string Type { get; set; } = default!;
        public object Size { get; set; } = default!;
        public int Quantity { get; set; } = default!;
    }
}
