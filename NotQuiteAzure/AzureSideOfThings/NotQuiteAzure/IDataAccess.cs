using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace NotQuiteAzure
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IDataAccess" in both code and config file together.
    [ServiceContract]
    public interface IDataAccess
    {
        [OperationContract]
        List<Customer> GetCustomers();

        [OperationContract]
        List<ClaimReference> GetClaims();

        [OperationContract]
        List<Policy> GetPolicies();

        [OperationContract]
        List<Call> GetCalls();
    }
}
