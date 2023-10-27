using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace PizzaStore
{
    class Store
    {
        private int userIntGlobal;

        public int GetUserIntGlobal()
        {
            return userIntGlobal;
        }

        public void SetUserIntGlobal(int value)
        {
            userIntGlobal = value;
        }

        public static int ReadUserInt()
        {
            string choice = Console.ReadLine() ?? string.Empty;
            if (int.TryParse(choice, out int input))
            {
                return input;
            }
            else
            {
                return -1;
            }
        }
        public static string ReadYesNo() 
        {
            string userConsole = Console.ReadLine() ?? string.Empty;
            userConsole = userConsole.ToLower();
            return userConsole;
        }
        public static int ShowStore()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Pizza Store!");
            Console.WriteLine("--Please choose an option--");
            Console.WriteLine("\t1. Show menu");
            Console.WriteLine("\t2. Other menu options");
            Console.WriteLine("\t3. Show customer list");
            Console.WriteLine("\t4. Other customer options");
            Console.WriteLine("\t5. Place order");
            Console.WriteLine("\t6. Show order log");
            Console.WriteLine("\t0. Exit");
            Console.WriteLine();
            return ReadUserInt();
        }
        public static int ShowMenuOptions()
        {
            Console.Clear();
            Console.WriteLine("--Menu options--");
            Console.WriteLine("\t1. Show menu");
            Console.WriteLine("\t2. Search menu");
            Console.WriteLine("\t3. Add or update menu item");
            Console.WriteLine("\t0. Back to main menu");
            Console.WriteLine();
            return ReadUserInt();
            
        }
        public static int ShowCustomerOptions()
        {
            Console.Clear();
            Console.WriteLine("--Customer options--");
            Console.WriteLine("\t1. Show customer list");
            Console.WriteLine("\t2. Add customer");
            Console.WriteLine("\t3. Update customer");
            Console.WriteLine("\t4. Delete customer");
            Console.WriteLine("\t0. Back to main menu");
            Console.WriteLine();
            return ReadUserInt();
        }
        public static void RunStore() 
        {
            int userInt = ShowStore(); // Returns an int with the ReadUserInt() method
            while (true)
            {
                switch (userInt)
                {
                    case 1: // Show menu
                        Console.Clear();
                        PizzaMenu.ShowMenu();
                        break;
                    case 2: // Other menu options
                        Console.Clear();
                        ShowMenuOptions();
                        PizzaMenu.SearchMenu();
                        break;
                    case 3: // Show customer list
                        Console.Clear();
                        CustomerFile.ShowCustomers();
                        break;
                    case 4: // Other customer options
                        Console.Clear();
                        ShowCustomerOptions();
                        break;
                    case 5: // Create order
                        Console.Clear();
                        Customer customer = CustomerFile.FindCustomer();
                        PizzaOrder pizzaOrder = new();
                        pizzaOrder = OrderHandler.CreatOrder(customer);
                        break;
                    case 6: // Show order log
                        Console.Clear();
                        OrderHandler.ShowLog();
                        break;
                    case 0:
                        Console.Clear();
                        Console.WriteLine("----------------");
                        Console.WriteLine("--- Goodbye! ---");
                        Console.WriteLine("----------------");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please choose a valid option.");
                        break;
                }
            }
        }
        public static void RunMenuOptions()
        {
            int userInt = ShowMenuOptions(); // Returns an int with the ReadUserInt() method
            while (true)
            {
                switch (userInt)
                {
                    case 1:
                        Console.Clear();
                        PizzaMenu.ShowMenu();
                        break;
                    case 2:
                        Console.Clear();
                        PizzaMenu.SearchMenu();
                        break;
                    case 3:
                        Console.Clear();
                        PizzaMenu.AddMenuItem();
                        break;
                    case 0: // Back to main menu
                        ShowStore();
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please choose a valid option.");
                        break;
                }
                ReadUserInt();
            }
        }
        public static void RunCustomerOptions()
        {
            int userInt = ShowCustomerOptions(); // Returns an int with the ReadUserInt() method
            while (true)
            {
                switch (userInt)
                {
                    case 1:
                        Console.Clear();
                        CustomerFile.ShowCustomers();
                        break;
                    case 2:
                        Console.Clear();
                        CustomerFile.AddCustomer();
                        break;
                    case 3:
                        Console.Clear();
                        CustomerFile.UpdateCustomer();
                        break;
                    case 4:
                        Console.Clear();
                        CustomerFile.DeleteCustomer();
                        break;
                    case 0: // Back to main menu
                        SetUserIntGlobal(ShowStore());
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please choose a valid option.");
                        break;
                }
                ReadUserInt();
            }
        }
    }
}
