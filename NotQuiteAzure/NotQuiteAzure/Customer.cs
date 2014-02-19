using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NotQuiteAzure
{
    public class Customer
    {
        public string id { get; set; }

        public DateTime dateOfBirth { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
	    public string homePhone { get; set; }
	    public string workPhone { get; set; }
	    public string address { get; set; }
	    public string email { get; set; }

        public List<Policy> Policies { get; set; }
    }
}
