using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore
{
    class Store
    {
        public static int ReadUserChoice()
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
            return ReadUserChoice();
        }

        public static int MenuOptions()
        {
            Console.Clear();
            Console.WriteLine("--Menu options--");
            Console.WriteLine("\t1. Show menu");
            Console.WriteLine("\t2. Search menu");
            Console.WriteLine("\t3. Add or update menu item");
            Console.WriteLine("\t0. Back to main menu");
            Console.WriteLine();
            return ReadUserChoice();
        }

        public static int CustomerOptions()
        {
            Console.Clear();
            Console.WriteLine("--Customer options--");
            Console.WriteLine("\t1. Show customer list");
            Console.WriteLine("\t2. Add customer");
            Console.WriteLine("\t3. Update customer");
            Console.WriteLine("\t4. Delete customer");
            Console.WriteLine("\t0. Back to main menu");
            Console.WriteLine();
            return ReadUserChoice();
        }
        public static string ReadYesNo() 
        {
            string userConsole = Console.ReadLine() ?? string.Empty;
            userConsole = userConsole.ToLower();
            return userConsole;
        }

        public static void RunStore() 
        {
            int userChoice = ShowStore(); //Returns an int with the ReadUserChoice() method
            while (ReadUserChoice() != 0)
            {
                switch (userChoice)
                {
                    case 1: // Show menu
                        Console.Clear();
                        PizzaMenu.ShowMenu();
                        break;
                    case 2: // Other menu options
                        Console.Clear();
                        MenuOptions();
                        PizzaMenu.SearchMenu();
                        break;
                    case 3: // Show customer list
                        Console.Clear();
                        CustomerFile.ShowCustomers();
                        break;
                    case 4: // Other customer options
                        Console.Clear();
                        CustomerOptions();
                        break;
                    case 5: // Create order
                        Console.Clear();
                        OrderHandler.CreatOrder();
                        break;
                    case 6: // Show order log
                        Console.Clear();
                        OrderHandler.ShowLog();
                        break;
                    case 0:
                        Console.Clear();
                        Console.WriteLine("Goodbye!\n");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please choose a valid option.");
                        break;
                }
            }
        }
    }
}
