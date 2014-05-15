using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Device.Location;

namespace NotQuiteAzure
{
    public class Claim
    {
        public GeoCoordinate location { get; set; }
        public Policy policy { get; set; }
        public List<AccidentPicture> accidentPictures { get; set; }
        public string customerId { get; set; }
    }
}
