using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMIClaimReporter.Model
{
    public class Claim
    {
        public string ClaimDate { get; set; }
        public string ClaimStatus { get; set; }
        public string InsuredName { get; set; }
        public string InsuredDob { get; set; }
        public string PolicyNo { get; set; }
        public string VehicleMake { get; set; }
        public string VehicleModel { get; set; }
        public string VehicleYear { get; set; }
        public string VehicleRegistration { get; set; }

        public Claim()
        {
        }
    }
}
