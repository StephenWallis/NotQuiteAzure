using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data.Odbc;
using System.Globalization;
using NotQuiteAWebUi.Models;

namespace NotQuiteAzure
{
    public class DatabaseConnection
    {
        string connectionString = "Server=(local)\\SQLEXPRESS;Initial Catalog=ClaimsReporting;Integrated Security=SSPI";

        public Customer Register(int customerNumber)
        {
            Customer customer = new Customer();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(
                    "SELECT TOP 1 cust_ID, name, custNo, DOB, home_phone, work_phone, address, email FROM Customers " +
                    "WHERE custNo = " + customerNumber, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        customer.id = reader.GetString(0);
                        customer.name = reader.GetString(1);
                        customer.custNo = reader.GetInt32(2);
                        customer.dateOfBirth = reader.GetDateTime(3);
                        customer.homePhone = reader.GetString(4);
                        customer.workPhone = reader.GetString(5);
                        customer.address = reader.GetString(6);
                        customer.email = reader.GetString(7);
                    }
                }
            }
            return customer;
        }

        public void CallMe(string customerNumber, string customerPhone)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {     
                SqlCommand nonqueryCommand = connection.CreateCommand();
                connection.Open();

                nonqueryCommand.CommandText = "INSERT INTO Call (custNo, phone_number) VALUES (@customerNumber, @customerPhone)";

                nonqueryCommand.Parameters.AddWithValue("@customerNumber", customerNumber);
                nonqueryCommand.Parameters.AddWithValue("@customerPhone", customerPhone);
                nonqueryCommand.ExecuteNonQuery();
            }
        }

        public void SubmitClaim(Claim claim)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand nonqueryCommand = connection.CreateCommand();
                connection.Open();

                nonqueryCommand.CommandText = "INSERT INTO Claims (claim_ID, policy_ID, cust_ID) VALUES (@claim_ID, @policy_ID, @cust_ID)";

                nonqueryCommand.Parameters.AddWithValue("@claim_ID", claim.id);
                nonqueryCommand.Parameters.AddWithValue("@policy_ID", claim.policyId);
                nonqueryCommand.Parameters.AddWithValue("@cust_ID", claim.customerId);
                nonqueryCommand.ExecuteNonQuery();
            }
        }

        public IEnumerable<CallMeModel> GetClaims()
        {
            var result = new List<CallMeModel>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(
                     "select cus.custno, cus.name, cus.DOB, cus.address, cus.home_phone, c.phone_number from Call c join Customers cus on c.cust_ID = cus.cust_IDs", connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var callMeModel = new CallMeModel
                        {
                            CustomerNumber = reader.GetString(0),
                            Name = reader.GetString(1),
                            DateOfBirth = reader.GetDateTime(2),
                            Address = reader.GetString(3),
                            HomePhone = reader.GetString(4),
                            PhoneNumber = reader.GetString(5)
                        };

                        result.Add(callMeModel);
                    }
                }
            }

            return result;
        }
    }
}