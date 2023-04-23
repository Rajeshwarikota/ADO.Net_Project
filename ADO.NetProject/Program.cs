using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NetProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(".....ADO.NET......");
            Console.WriteLine("Select any one Option for \n" +
               "1. Add customer details into customer table \n" +
               "2. Get all customers details \n" +
               "3. Delete any one customer from database \n" +
               "4. Update customer salary based on customer name");
            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    Customer customer = new Customer();
                    Console.WriteLine("Enter Customer Name");
                    customer.Name = Console.ReadLine();
                    Console.WriteLine("Enter Customer City");
                    customer.City = Console.ReadLine();
                    Console.WriteLine("Enter Customer Address");
                    customer.Address = Console.ReadLine();
                    Console.WriteLine("Enter Customer Phone Number");
                    customer.PhoneNumber = Convert.ToInt64(Console.ReadLine());
                    Console.WriteLine("Enter Customer Salary");
                    customer.Salary = Convert.ToInt64(Console.ReadLine());

                    CustomerRepository.AddCustomer(customer);
                    break;
                case 2:
                    CustomerRepository.GetAllCustomer();
                    break;
                case 3:

                    // create a new customer object
                    Customer customerToDelete = new Customer();
                    customerToDelete.Name = "Raji";
                    customerToDelete.City = "Hyd"; // new parameter
                    CustomerRepository.DeleteCustomer(customerToDelete);
                    Console.ReadLine();
                    break;
                 case 4:
                    Console.WriteLine("Enter Customer Name whos salary u want to update");
                    string customerName = Console.ReadLine();
                    Console.WriteLine("Enter Updated Salary");
                    long updateSalary = Convert.ToInt64(Console.ReadLine());
                    Customer customer2 = new Customer();
                    customer2.Name = customerName;
                    customer2.Salary = updateSalary;
                    
                    CustomerRepository.UpdateCustomer(customer2);
                    break;
                default:
                    Console.WriteLine("Please Select Correct Option");
                    break;
            }
                    Console.ReadLine();
        }
    }
}
