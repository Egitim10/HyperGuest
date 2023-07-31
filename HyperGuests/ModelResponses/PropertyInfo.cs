using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperGuests.ModelResponses
{
    public class PropertyInfo
    {
        public string Name { get; set; } = default!;
        public int StarRating { get; set; }
        public string CityName { get; set; } = default!;
        public int CityId { get; set; }
        public string CountryName { get; set; } = default!;
        public string CountryCode { get; set; } = default!;
        public string RegionName { get; set; }= default!;
        public string RegionCode { get; set; } = default!;
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public int PropertyType { get; set; }
        public string PropertyTypeName { get; set; } = default!;
    }
}
