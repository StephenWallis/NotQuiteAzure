using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace NotQuiteAzure
{
    public class NotQuiteAzure : INotQuiteAzure
    {
        public Customer Register(int customerNumber)
        {
            DatabaseConnection databaseConnection = new DatabaseConnection();

            try { return databaseConnection.GetCustomer(customerNumber); }
            catch { return new Customer(); }
        }

        public bool CustomerCallRequest(string customerId, string customerPhone)
        {
            DatabaseConnection databaseConnection = new DatabaseConnection();

            try 
            { 
                databaseConnection.CreateCall(customerId, customerPhone);
                return true;
            }
            catch { return false; }
        }

        public bool RecordClaim(Claim claim)
        {
            DatabaseConnection databaseConnection = new DatabaseConnection();

            try
            {
                databaseConnection.CreateClaim(claim);
                return true;
            }
            catch { return false; }
        }
    }
}
