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
        public Customer Register(int id)
        {
            throw new NotImplementedException();

            // retrieve customer from DB for id
            // if customer not present return null, let Ken deal with it
            // return the customer information, including policies collection it contains (convert db object to customer)
        }

        public bool CustomerCallRequest(int id, string customerPhone)
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
