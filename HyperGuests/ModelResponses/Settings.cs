using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperGuests.ModelResponses
{
    public class Settings
    {
        public int NumberOfBedrooms { get; set; }
        public int RoomSize { get; set; }
        public int MaxAdultsNumber { get; set; }
        public int MaxChildrenNumber { get; set; }
        public int MaxInfantsNumber { get; set; }
        public int MaxOccupancy { get; set; }
        public int NumberOfBeds { get; set; }
        public List<BeddingConfiguration> BeddingConfigurations { get; set; } = new();
    }
}
