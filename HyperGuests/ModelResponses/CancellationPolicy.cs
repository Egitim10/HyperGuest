using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperGuests.ModelResponses
{
    public class CancellationPolicy
    {
        public int DaysBefore { get; set; }
        public string PenaltyType { get; set; } = default!;
        public int Amount { get; set; }
        public TimeSetting TimeSetting { get; set; }= default!;
        public string CancellationDeadlineHour { get; set; } = default!;
    }
}
