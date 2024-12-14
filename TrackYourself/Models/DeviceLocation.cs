using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackYourself.Models
{
    public class DeviceLocation
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public DeviceLocation(double lat, double lng)
        {  Latitude = lat; Longitude = lng;}
    }
}
