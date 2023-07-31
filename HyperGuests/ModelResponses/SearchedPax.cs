using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperGuests.ModelResponses
{
    public class SearchedPax
    {
        public int Adults { get; set; }
        public List<object> Children { get; set; } = new();
    }
}
