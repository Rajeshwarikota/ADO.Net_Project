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
        public static string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog = ADONET;Integrated Security = True;Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent = ReadWrite; MultiSubnetFailover=False";
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
    }
}
