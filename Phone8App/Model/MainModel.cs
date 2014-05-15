using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Device.Location;

namespace AMIClaimReporter.Model
{

    public class MainModel
    {
        #region Properties

        public string QRCode { get; set; }
        public string CustomerNo { get; set; }
        public string InsuredName { get; set; }
        public string InsuredDob { get; set; }

        public string InsuredPhoneHome { get; set; }
        public string InsuredPhoneBusiness { get; set; }
        public string InsuredAddress { get; set; }
        public string InsuredEmail { get; set; }

        public List<Claim> Claims { get; set; }
        public Claim SelectedClaim { get; set; }

        public ObservableCollection<Policy> Policies { get; set; }
        public Policy SelectedPolicy { get; set; }

        public GeoCoordinate CurrentLocation { get; set; }

        #endregion

        public MainModel()
        {
            Claims = new List<Claim>();
            Policies = new ObservableCollection<Policy>();
        }
    }
}
