using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADO.NetProject;
using static System.Net.Mime.MediaTypeNames;
using System.Runtime.Remoting.Contexts;

namespace ADO.NetProject
{
    public class CustomerRepository
    {
        public static string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ADONET;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static void AddCustomer(Customer model)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(ConnectionString);

                SqlCommand cmd = new SqlCommand("SPADDCUSTOMERS", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();
                cmd.Parameters.AddWithValue("@Name", model.Name);
                cmd.Parameters.AddWithValue("@City", model.City);
                cmd.Parameters.AddWithValue("@Address", model.Address);
                cmd.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);
                cmd.Parameters.AddWithValue("@Salary", model.Salary);

                int num = cmd.ExecuteNonQuery();
                if (num != 0)
                {
                    Console.WriteLine("Customer added Successfully");
                }
                else
                {
                    Console.WriteLine("Something went Wrong");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void GetAllCustomer()
        {
            try
            {
                Customer customer = new Customer();
                SqlConnection sqlConnection = new SqlConnection(ConnectionString);
                string query = "select * from Customer";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        customer.Id = Convert.ToInt32(reader["Id"] == DBNull.Value ? default : reader["Id"]);
                        customer.Name = (reader["Name"] == DBNull.Value ? default : reader["Name"]).ToString();
                        customer.City = (reader["City"] == DBNull.Value ? default : reader["City"]).ToString();
                        customer.Address = (reader["Address"] == DBNull.Value ? default : reader["Address"]).ToString();
                        customer.PhoneNumber = (int)Convert.ToInt64(reader["PhoneNumber"] == DBNull.Value ? default : reader["PhoneNumber"]);
                        customer.Salary = (int)Convert.ToInt64(reader["Salary"] == DBNull.Value ? default : reader["Salary"]);

                        Console.WriteLine(customer.Id + "\n" + customer.Name + "\n" + customer.City + "\n" + customer.Address + "\n" + customer.PhoneNumber + "\n" + customer.Salary);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void DeleteCustomer(Customer model)
        {
                try
                {
                    SqlConnection sqlConnection = new SqlConnection(ConnectionString);
                    SqlCommand sqlcommand = new SqlCommand("SPDELETECUSTOMERS", sqlConnection);
                    sqlcommand.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();
                    sqlcommand.Parameters.AddWithValue("@Name", model.Name);
                    sqlcommand.Parameters.AddWithValue("@City", model.City); 
                    int num = sqlcommand.ExecuteNonQuery();
                    if (num != 0)
                    {
                        Console.WriteLine("Customer Delete Successfully");
                    }
                    else
                    {
                        Console.WriteLine("Something went Wrong in Delete Customer");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
        }
    }
}
