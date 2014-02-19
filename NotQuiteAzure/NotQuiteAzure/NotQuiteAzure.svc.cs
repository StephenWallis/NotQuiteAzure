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
        public Customer Register(string customerId)
        {
            DatabaseConnection databaseConnection = new DatabaseConnection();
            return databaseConnection.GetCustomer(customerId);
        }

        public bool CustomerCallRequest(string customerId, string customerPhone)
        {
            throw new NotImplementedException();

            // post to Calls table the customerPhone & id (stored proc???)
            // return success of call
        }

        public bool RecordClaim(Claim claim)
        {
            throw new NotImplementedException();

            // post to Claims table the claim info (stored proc???)
            // return success of call
        }
    }
}
