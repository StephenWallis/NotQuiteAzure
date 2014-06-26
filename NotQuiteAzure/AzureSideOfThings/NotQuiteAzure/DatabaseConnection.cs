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
using System.Configuration;

namespace NotQuiteAzure
{
    public class DatabaseConnection
    {
        string connectionString = ConfigurationManager.ConnectionStrings["SQLAzureConnection"].ToString();
        
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
                        customer.Policies = new List<Policy>();
                    }
                }

                using (SqlCommand command2 = new SqlCommand(
                    "SELECT policy_ID, registration, vehicle_make, vehicle_model FROM Policy " +
                    "WHERE custno = (SELECT TOP 1 custno FROM Customers WHERE CustNo = " + customerNumber + ")", connection))
                using (SqlDataReader reader = command2.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        customer.Policies.Add(
                            new Policy()
                            {
                                id = reader.GetString(0),
                                registration = reader.GetString(1),
                                make = reader.GetString(2),
                                model = reader.GetString(3)
                            });
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

        public void RecordClaim(Claim claim)
        {
            //TODO: sort out making proper IDs at some point. For now just mash a whole lot of data together and call it an id
            string policyId = claim.customerId + claim.policy.registration + claim.location.Latitude.ToString() + claim.location.Longitude.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand nonqueryCommand = connection.CreateCommand();
                connection.Open();

                nonqueryCommand.CommandText = "INSERT INTO Policy (policy_ID, vehicle_make, vehicle_model, registration, custNo) VALUES (@policy_ID, @vehicle_make, @vehicle_model, @registration, @cust_ID)";

                nonqueryCommand.Parameters.AddWithValue("@policy_ID", policyId);
                nonqueryCommand.Parameters.AddWithValue("@vehicle_make", claim.policy.make);
                nonqueryCommand.Parameters.AddWithValue("@vehicle_model", claim.policy.model);
                nonqueryCommand.Parameters.AddWithValue("@registration", claim.policy.registration);
                nonqueryCommand.Parameters.AddWithValue("@cust_ID", claim.customerId);
                nonqueryCommand.ExecuteNonQuery();
            }

            using (SqlConnection connection2 = new SqlConnection(connectionString))
            {
                SqlCommand nonqueryCommand = connection2.CreateCommand();
                connection2.Open();

                nonqueryCommand.CommandText = "INSERT INTO Claims (custNo, longatude, latitude, policy_ID) VALUES (@cust_ID, @longatude, @latitude, @policy_ID)";

                nonqueryCommand.Parameters.AddWithValue("@cust_ID", claim.customerId);
                nonqueryCommand.Parameters.AddWithValue("@longatude", claim.location.Longitude);
                nonqueryCommand.Parameters.AddWithValue("@latitude", claim.location.Latitude);
                nonqueryCommand.Parameters.AddWithValue("@policy_ID", policyId);
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

        public List<Customer> GetCustomers()
        {
            var result = new List<Customer>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(
                    "SELECT custNo, Name, DOB, home_phone, work_phone, address, email "+
                    "FROM Customers", connection
                    ))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new Customer
                        {
                            custNo = reader.GetInt32(0),
                            name = reader.GetString(1),
                            dateOfBirth = reader.GetDateTime(2),
                            homePhone = reader.GetString(3),
                            workPhone = reader.GetString(4),
                            address = reader.GetString(5),
                            email = reader.GetString(6)
                        });
                    }
                }
            }
            return result;
        }

        public List<ClaimReference> GetAllClaims()
        {
            var result = new List<ClaimReference>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(
                    "SELECT claim_ID, policy_ID, cust_ID, longatude, latitude "+
                    "FROM Claims", connection
                    ))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new ClaimReference
                        {
                          claimId = reader.GetString(0),
                          policyId = reader.GetString(1),
                          customerId = reader.GetString(2),
                          longatude = reader.GetString(3),
                          latitude = reader.GetString(4)
                        });
                    }
                }
            }
            return result;
        
        }

        public List<Policy> GetPolicies()
        {
            var result = new List<Policy>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(
                    "SELECT policy_ID, custNo, vehicle_make, vehicle_model, registration " +
                    "FROM Policy", connection
                    ))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new Policy()
                        {
                            id = reader.GetString(0),
                            customerId = reader.GetString(1),
                            make = reader.GetString(2),
                            model = reader.GetString(3),
                            registration = reader.GetString(4)
                        });
                    }
                }
            }
            return result;
        }

        public List<Call> GetCalls()
        {
            var result = new List<Call>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(
                    "SELECT Name, Call.custNo, phone_number " +
                    "FROM Call, Customers "+
                    "WHERE Call.custNo = Customers.custNo", connection
                    ))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new Call()
                        {
                            name = reader.GetString(0),
                            custNo = int.Parse(reader.GetString(1)),
                            callNo = reader.GetString(2)
                        });
                    }
                }
            }
            return result;

        }
    }
}