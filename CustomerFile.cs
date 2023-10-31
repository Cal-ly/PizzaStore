using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace PizzaStore
{
    public class CustomerFile
    {
        public static List<Customer> Customers { get; set; } = new() { };

        static CustomerFile()
        {
            Customer customer1 = new();
            Customers.Add(customer1); //Customer ID 1000 is now default customer (e.g. walk-in customer)
        }

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
            Console.WriteLine("Is customer member of PizzaPals? (y/n)");
            string member = Console.ReadLine() ?? string.Empty;
            member?.ToLower();
            bool memberBool = false;
            if (member == "y") { memberBool = true; }
            else if (member == "n") { memberBool = false; }
            else { Console.WriteLine("Invalid input, try again"); }

            if (string.IsNullOrEmpty(name) || 
                string.IsNullOrEmpty(address) || 
                string.IsNullOrEmpty(postalCode) || 
                string.IsNullOrEmpty(city) ||
                string.IsNullOrEmpty(phoneNumber) ||
                string.IsNullOrEmpty(member) )
            {
                Console.WriteLine("Some fields have been left empty\nYou can update the customer again, if needed");
            }

            Customer customer = new(name, address, postalCode, city, phoneNumber, memberBool);
            Customers.Add(customer);
            Console.WriteLine($"{customer.Name} has been added to the customer list.\n");
            Console.WriteLine(customer);
            Console.WriteLine();
        }
        public static void ShowCustomers()
        {
            Console.WriteLine("Customer list:");
            foreach (Customer customer in Customers)
            {
                Console.WriteLine(customer);
            }
            Console.WriteLine();
        }
        public static void UpdateCustomer()
        {
            bool loopHasRun = false;
            Console.WriteLine("Enter customer ID, for the customer you want to update");
            int updateID = Store.ReadCustomerInt();
            foreach (Customer costumer in Customers)
            {
                bool hasUpdated = false;
                if (Customers.Any(costumer => costumer.Id == updateID))
                {
                    Console.WriteLine("Update name? (y/n)");
                    if (Console.ReadLine() == "y")
                    {
                        Console.WriteLine("Enter customer name:");
                        string name = Console.ReadLine() ?? string.Empty;
                        costumer.Name = name;
                        hasUpdated = true;
                    }
                    Console.WriteLine("Update address? (y/n)");
                    if (Console.ReadLine() == "y")
                    {
                        Console.WriteLine("Enter customer address:");
                        string address = Console.ReadLine() ?? string.Empty;
                        costumer.Address = address;
                        hasUpdated = true;
                    }
                    Console.WriteLine("Update postal code? (y/n)");
                    if (Console.ReadLine() == "y")
                    {
                        Console.WriteLine("Enter customer postal code:");
                        string postalCode = Console.ReadLine() ?? string.Empty;
                        costumer.PostalCode = postalCode;
                        hasUpdated = true;
                    }
                    Console.WriteLine("Update city? (y/n)");
                    if (Console.ReadLine() == "y")
                    {
                        Console.WriteLine("Enter customer city:");
                        string city = Console.ReadLine() ?? string.Empty;
                        costumer.City = city;
                        hasUpdated = true;
                    }
                    Console.WriteLine("Update phone number? (y/n)");
                    if (Console.ReadLine() == "y")
                    {
                        Console.WriteLine("Enter customer phone number:");
                        string phoneNumber = Console.ReadLine() ?? string.Empty;
                        costumer.PhoneNumber = phoneNumber;
                        hasUpdated = true;
                    }
                    Console.WriteLine("Update membership? (y/n)");
                    if(Console.ReadLine() == "y")
                    {
                        Console.WriteLine("Is customer member of PizzaPals? (y/n)");
                        string member = Console.ReadLine() ?? string.Empty;
                        member?.ToLower();
                        bool memberBool;
                        if (member == "y")
                        {
                            memberBool = true;
                            costumer.Member = memberBool;
                            hasUpdated = true;
                        }
                        else if (member == "n")
                        {
                            memberBool = false;
                            costumer.Member = memberBool;
                            hasUpdated = true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input, try again");
                        }
                    }
                    if (hasUpdated == false)
                    {
                        Console.WriteLine("No information has been updated");
                    }
                    else if (hasUpdated == true)
                    {
                        Console.WriteLine($"Customer #{costumer.Id} {costumer.Name} has been updated.\n");
                        Console.WriteLine($"Updated information: {costumer}");
                        Console.WriteLine();
                    }
                    break;
                }
            }
            if (loopHasRun == false) { Console.WriteLine("Invalid ID, please try again"); }
        }
        public static void DeleteCustomer()
        {
            bool loopRun = false;
            Console.WriteLine("Enter customer ID, for the customer you want to delete");
            int deleteID = Store.ReadCustomerInt();
            foreach (Customer customer in Customers)
            {
                if (customer.Id == deleteID)
                {
                    Console.WriteLine($"Customer {customer.Name} has been deleted from the customer list.\n");
                    Customers.Remove(customer);
                    break;
                }
            }
            if (loopRun == false) { Console.WriteLine("Invalid ID, please try again"); }
        }

        public static Customer FindCustomer(int customerId)
        {
            if (Customers.Any(c => c.Id == customerId) == false) // Check if customer ID exists
            {
                while (Customers.Any(c => c.Id == customerId) == false)
                {
                    Console.WriteLine("Customer ID does not exist, enter '1000' for default customer");
                    Console.WriteLine("Please try again");
                    customerId = Store.ReadUserInt();
                }
            }
            else if (Customers.Any(c => c.Id == customerId) == true)
            {
                Customer tempCustomer = Customers.First(c => c.Id == customerId);
                Console.WriteLine("Customer ID found:");
                Console.WriteLine(tempCustomer);
                return tempCustomer;
            }
            Console.WriteLine("Error - System will use Default Customer");
            Customer defaultCustomer = new();
            return defaultCustomer;
        }
    }
}
