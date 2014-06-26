using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace NotQuiteAzure
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DataAccess" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select DataAccess.svc or DataAccess.svc.cs at the Solution Explorer and start debugging.
    public class DataAccess : IDataAccess
    {
        public List<Customer> GetCustomers()
        {

            var databaseConnection = new DatabaseConnection();

            try
            {
                return databaseConnection.GetCustomers();
            }
            catch (Exception e)
            {
                Console.Write(e);
                return new List<Customer>();
            }
        }

        public List<ClaimReference> GetClaims()
        {
            var databaseConnection = new DatabaseConnection();

            try
            {
                return databaseConnection.GetAllClaims();
            }
            catch (Exception e)
            {
                Console.Write(e);
                return new List<ClaimReference>();
            }
        }


        public List<Policy> GetPolicies()
        {
            var databaseConnection = new DatabaseConnection();

            try
            {
                return databaseConnection.GetPolicies();
            }
            catch (Exception e)
            {
                Console.Write(e);
                return new List<Policy>();
            }
        }

        public List<Call> GetCalls()
        {
            var databaseConnection = new DatabaseConnection();

            try
            {
                return databaseConnection.GetCalls();
            }
            catch (Exception e)
            {
                Console.Write(e);
                return new List<Call>();
            }
        }
    }
}
