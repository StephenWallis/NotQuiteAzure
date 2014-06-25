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
        public Customer Register(int customerNumber)
        {
            DatabaseConnection databaseConnection = new DatabaseConnection();

            try { return databaseConnection.Register(customerNumber); }
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

        public string RegisterClaim(string customerId, double longitude, double latitude, 
            string vehicleMake, string vehicleModel, string vehicleRegistration)
        {
            GeoCoordinate location = new GeoCoordinate() { Latitude = latitude, Longitude = longitude };
            Policy policy = new Policy { make = vehicleMake, model = vehicleModel, registration = vehicleRegistration };
            Claim claim = new Claim() { customerId = customerId, location = location, policy = policy };

            DatabaseConnection databaseConnection = new DatabaseConnection();

            try
            {
                return databaseConnection.RegisterClaim(claim);
            }
            catch { return "ERROR! DANGER! CHAOS! BAD-STUFF!"; }
        }
    }
}
