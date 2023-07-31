using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperGuests.ModelResponses
{
    public class TimeSetting
    {
        public int TimeFromCheckIn { get; set; }
        public string TimeFromCheckInType { get; set; } = default!;
    }
}
