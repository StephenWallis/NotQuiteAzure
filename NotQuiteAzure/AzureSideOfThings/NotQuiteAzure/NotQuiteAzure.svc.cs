using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Device.Location;

namespace NotQuiteAzure
{
    public class NotQuiteAzure : INotQuiteAzure
    {
        public Customer Register(string customerId)
        {
            DatabaseConnection databaseConnection = new DatabaseConnection();

            try { return databaseConnection.Register(customerId); }
            catch { return new Customer(); }
        }

        public bool CallMe(string customerId, string customerPhone)
        {
            DatabaseConnection databaseConnection = new DatabaseConnection();

            try 
            { 
                databaseConnection.CallMe(customerId, customerPhone);
                return true;
            }
            catch { return false; }
        }

        public string RegisterClaim(string customerId, double longitude, double latitude, string policyNumber)
        {
            GeoCoordinate location = new GeoCoordinate() { Latitude = latitude, Longitude = longitude };
            Claim claim = new Claim() { customerId = customerId, location = location };

            DatabaseConnection databaseConnection = new DatabaseConnection();

            try
            {
                return databaseConnection.RegisterClaim(claim, policyNumber);
            }
            catch { return "ERROR! DANGER! CHAOS! BAD-STUFF!"; }
        }
    }
}
