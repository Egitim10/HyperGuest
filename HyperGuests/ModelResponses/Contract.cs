using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperGuests.ModelResponses
{
    public class Contract
    {
        public int ContractId { get; set; }
        public List<ContractTerm> Terms { get; set; } = new();
    }
}
