using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore
{
    class CustomerFile
    {
        public static List<Customer> Customers { get; set;  } = new List<Customer>() { };

        public static void AddCustomer()
        {
            Console.WriteLine("Enter customer name:");
            string name = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Enter customer address:");
            string address = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Enter customer postal code:");
            string postalCode = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Enter customer city:");
            string city = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Enter customer phone number:");
            string phoneNumber = Console.ReadLine() ?? string.Empty;
            Customer customer = new(name, address, postalCode, city, phoneNumber);
            Customers.Add(customer);
            Console.WriteLine($"Customer {customer.Name} has been added to the customer list.\n");
        }
        public static void ShowCustomers()
        {
            Console.WriteLine("Customer list:");
            foreach (Customer customer in Customers)
            {
                Console.WriteLine($"ID: {customer.Id}, Name: {customer.Name}, Address: {customer.Address}, Postal Code: {customer.PostalCode}, City: {customer.City}, Phone Number: {customer.PhoneNumber}");
            }
            Console.WriteLine();
        }
        public static void UpdateCustomer()
        {
            Console.WriteLine("Enter customer ID, for the customer you want to delete");
            string updateID = Console.ReadLine() ?? string.Empty;
            int updateIDInt = int.Parse(updateID);
            foreach (Customer customer in Customers)
            {
                if (customer.Id == updateIDInt)
                {
                    Console.WriteLine("Enter customer name:");
                    string name = Console.ReadLine() ?? string.Empty;
                    Console.WriteLine("Enter customer address:");
                    string address = Console.ReadLine() ?? string.Empty;
                    Console.WriteLine("Enter customer postal code:");
                    string postalCode = Console.ReadLine() ?? string.Empty;
                    Console.WriteLine("Enter customer city:");
                    string city = Console.ReadLine() ?? string.Empty;
                    Console.WriteLine("Enter customer phone number:");
                    string phoneNumber = Console.ReadLine() ?? string.Empty;
                    customer.Name = name;
                    customer.Address = address;
                    customer.PostalCode = postalCode;
                    customer.City = city;
                    customer.PhoneNumber = phoneNumber;
                    Console.WriteLine($"Customer {customer.Name} has been updated.\n");
                    break;
                }
                else { Console.WriteLine("Invalid ID, please try again");  }
            }
        }
        public static void DeleteCustomer()
        {
            Console.WriteLine("Enter customer ID, for the customer you want to delete");
            string deleteID = Console.ReadLine() ?? string.Empty;
            int deleteIDInt = int.Parse(deleteID);
            foreach (Customer customer in Customers)
            {
                if (customer.Id == deleteIDInt)
                {
                    Customers.Remove(customer);
                    Console.WriteLine($"Customer {customer.Name} has been deleted from the customer list.\n");
                    break;
                }
                else { Console.WriteLine("Invalid ID, please try again"); }
            }
        }
    }
}
