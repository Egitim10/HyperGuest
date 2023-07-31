using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperGuests.ModelResponses
{
    public class Result
    {
        public int PropertyId { get; set; }
        public PropertyInfo PropertyInfo { get; set; } = default!;
        public List<string> Remarks { get; set; } = new();
        public List<Room> Rooms { get; set; } = new();
    }
}
