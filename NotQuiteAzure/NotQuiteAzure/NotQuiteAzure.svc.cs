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
        }

        public bool CustomerCallRequest(string customerNumber)
        {
            throw new NotImplementedException();
        }

        public bool RecordClaim(Claim claim)
        {
            throw new NotImplementedException();
        }
    }
}
