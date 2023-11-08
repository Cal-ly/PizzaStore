namespace PizzaStore
{
    static class Store
    {
        // Compiler will automatically construct a default constructor if none is defined
        #region Method
        public static int ReadUserInt()
        {
            string input = Console.ReadLine() ?? string.Empty;
            int output = int.TryParse(input, out int result) ? result : -1; // Shorter than If-else statement
            return output;
        }
        public static string ReadYesNo()
        {
            string userConsole = Console.ReadLine() ?? string.Empty;
            userConsole = userConsole.ToLower();
            return userConsole;
        }
        public static int ReadCustomerInt()
        {
            Console.WriteLine("Enter customer ID:");
            string customerStringID = Console.ReadLine() ?? string.Empty;
            int customerId = int.Parse(customerStringID);
            return customerId;
        }
        public static void PressKeyToCont()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
        public static void ShowMenuOptions()
        {
            Console.WriteLine("--Menu options--");
            Console.WriteLine("\t1. Show menu");
            Console.WriteLine("\t2. Search menu");
            Console.WriteLine("\t3. Add or update menu item");
            Console.WriteLine("\t0. Back to main menu");
            Console.WriteLine();
        }
        public static void RunMenuOptions()
        {
            ShowMenuOptions();
            while (true)
            {
                switch (ReadUserInt())
                {
                    case 1:
                        Console.Clear();
                        PizzaMenu.ShowMenu();
                        Console.WriteLine();
                        ShowMenuOptions();
                        break;
                    case 2:
                        Console.Clear();
                        PizzaMenu.SearchMenu();
                        ShowMenuOptions();
                        break;
                    case 3:
                        Console.Clear();
                        PizzaMenu.AddMenuItem();
                        ShowMenuOptions();
                        break;
                    case 0: // Back to main menu
                        Console.Clear();
                        RunStore();
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please choose a valid option.");
                        break;
                }
            }
        }
        public static void ShowCustomerOptions()
        {
            Console.WriteLine("--Customer options--");
            Console.WriteLine("\t1. Show customer list");
            Console.WriteLine("\t2. Add customer");
            Console.WriteLine("\t3. Update customer");
            Console.WriteLine("\t4. Delete customer");
            Console.WriteLine("\t0. Back to main menu");
            Console.WriteLine();
        }
        public static void RunCustomerOptions()
        {
            ShowCustomerOptions();
            while (true)
            {
                switch (ReadUserInt())
                {
                    case 1:
                        Console.Clear();
                        CustomerFile.ShowCustomers();
                        ShowCustomerOptions();
                        break;
                    case 2:
                        Console.Clear();
                        CustomerFile.AddCustomer();
                        ShowCustomerOptions();
                        break;
                    case 3:
                        Console.Clear();
                        CustomerFile.UpdateCustomer();
                        ShowCustomerOptions();
                        break;
                    case 4:
                        Console.Clear();
                        CustomerFile.DeleteCustomer();
                        ShowCustomerOptions();
                        break;
                    case 0: // Back to main menu
                        Console.Clear();
                        RunStore();
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please choose a valid option.");
                        break;
                }
            }
        }
        public static void ShowStore()
        {
            //Console.Clear();
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
        }
        public static void RunStore()
        {
            ShowStore();
            while (true)
            {
                switch (ReadUserInt())
                {
                    case 1: // Show menu
                        Console.Clear();
                        PizzaMenu.ShowMenu();
                        Console.WriteLine();
                        ShowStore();
                        break;
                    case 2: // Other menu options
                        Console.Clear();
                        RunMenuOptions();
                        break;
                    case 3: // Show customer list
                        Console.Clear();
                        CustomerFile.ShowCustomers();
                        ShowStore();
                        break;
                    case 4: // Other customer options
                        Console.Clear();
                        RunCustomerOptions();
                        break;
                    case 5: // Create order
                        Console.Clear();
                        OrderHandler.CreatOrder();
                        ShowStore();
                        break;
                    case 6: // Show order log
                        Console.Clear();
                        OrderHandler.ShowLog();
                        ShowStore();
                        break;
                    case 0:
                        string table = "┬─┬ノ( º _ ºノ)";
                        string tableFlip = "┻━┻ ︵╰(°□°╰)";
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine(table); // ┬─┬ノ( º _ ºノ)
                        Console.WriteLine("\nPress any key to flip the table\n");
                        Console.ReadKey();
                        Console.WriteLine(tableFlip); // ┻━┻ ︵╰(°□°╰)
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please choose a valid option.");
                        break;
                }
            }
        }
        #endregion
    }
}