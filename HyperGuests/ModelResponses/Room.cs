using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperGuests.ModelResponses
{
    public class Room
    {
        public SearchedPax SearchedPax { get; set; } = new();
        public int RoomId { get; set; }
        public string RoomTypeCode { get; set; } = default!;
        public string RoomName { get; set; } = default!;
        public int NumberOfAvailableRooms { get; set; }
        public Settings Settings { get; set; } = default!;
        public List<RatePlan> RatePlans { get; set; } = default!;
    }
}
