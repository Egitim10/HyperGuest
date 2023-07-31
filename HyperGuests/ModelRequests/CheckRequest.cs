using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperGuests.ModelRequests
{
    public class CheckRequest
    {
        public string Domain { get; set; } = default!;
        public int Nights { get; set; } = default!;
        public int Guests { get; set; } = default!;
        public int HotelId { get; set; } = default!;
        public string CheckInDate { get; init; }= default!; 
        public CheckRequest(string checkDate,string domain)
        {
            CheckInDate= checkDate; //serverda utc ise...
            Domain = domain;
        }
    }
}
