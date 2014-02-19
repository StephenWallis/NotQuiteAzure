using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data.Odbc;
using System.Globalization;

namespace NotQuiteAzure
{
    public class DatabaseConnection
    {
        public Customer GetCustomer(string customerId)
        {
            string connectionString = "connectionString";
            Customer customer = new Customer();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(
                    "SELECT TOP 1 cust_ID, name, DOB, home_phone, work_phone, address, email FROM Customers " +
                    "WHERE cust_ID = " + customerId, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        customer.id = reader.GetString(0);
                        customer.name = reader.GetString(1);
                        customer.dateOfBirth = reader.GetDateTime(2);
                        customer.homePhone = reader.GetString(3);
                        customer.workPhone = reader.GetString(4);
                        customer.address = reader.GetString(5);
                        customer.email = reader.GetString(6);
                    }
                }
            }
            return customer;
        }

    }
}