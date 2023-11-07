namespace PizzaStore
{
    public class PizzaMenu
    {
        public static Dictionary<int, Pizza> Menu { get; } = new()
        {
            { 1, new Pizza(1, "Margherita", 101.00) },
            { 2, new Pizza(2, "Vesuvio", 102.00) },
            { 3, new Pizza(3, "Capricciosa", 103.00) },
            { 4, new Pizza(4, "Calzone", 104.00) },
            { 5, new Pizza(5, "Hawaii", 105.00) },
            { 6, new Pizza(6, "Quattro Stagioni", 106.00) }
        };

        static PizzaMenu()
        {
        }

        #region Methods
        public static void ShowMenu()
        {
            Console.Write("Big Mamma a la Carte, Bon Appetit <3\n");
            foreach (var item in Menu)
            {
                Console.Write($"#{item.Key} - {item.Value.Name} - {item.Value.Price:F2} kr\n");
            }
        }
        public static void AddMenuItem() //Can both add and overwrite a Menu item
        {
            Console.WriteLine("Type a list number for the new pizza:");
            if (int.TryParse(Console.ReadLine(), out int entryNum))
            {
                if (Menu.ContainsKey(entryNum))
                {
                    Console.WriteLine("The entry exists and will be overwritten (y/n)");
                    string overWrite = Store.ReadYesNo();
                    Console.WriteLine();
                    if (string.IsNullOrEmpty(overWrite))
                    {
                        Console.WriteLine("Invalid entry, try again");
                    }
                    else if (overWrite == "y")
                    {
                        Console.WriteLine("Type name for the new pizza:");
                        string entryName = Store.ReadYesNo();
                        Console.WriteLine();
                        if (string.IsNullOrEmpty(entryName))
                        {
                            Console.WriteLine("Invalid entry, try again");
                        }
                        else
                        {
                            Console.WriteLine("Type price for the new pizza:");
                            if (double.TryParse(Console.ReadLine(), out double entryPrice))
                            {
                                Console.WriteLine();
                                if (entryPrice < 0)
                                {
                                    Console.WriteLine("Invalid price input. Please enter a valid positive number.");
                                }
                                else
                                {
                                    Menu.Remove(entryNum);
                                    Menu.Add(entryNum, new Pizza(entryNum, entryName, entryPrice));
                                    Console.WriteLine("Menu item updated successfully.");
                                    Console.WriteLine();
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("New menu entry has been canceled");
                    }
                }
                else
                {
                    Console.WriteLine("Type name for the new pizza:");
                    string entryName = Console.ReadLine() ?? string.Empty;
                    Console.WriteLine();
                    if (!string.IsNullOrEmpty(entryName))
                    {
                        Console.WriteLine("Type price for the new pizza:");
                        if (double.TryParse(Console.ReadLine(), out double entryPrice))
                        {
                            Console.WriteLine();
                            if (entryPrice < 0)
                            {
                                Console.WriteLine("Invalid price input. Please enter a valid positive number.");
                            }
                            else
                            {
                                entryPrice = Math.Round(entryPrice, 2);
                                Menu.Add(entryNum, new Pizza(entryNum, entryName, entryPrice));
                                Console.WriteLine("New menu item added successfully.");
                                Console.WriteLine();
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid entry, try again");
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid price input. Please enter a valid positive number.");
            }
        }
        public static void DeleteMenuItem(int deleteNumber)
        {
            if (Menu.ContainsKey(deleteNumber))
            {
                Console.WriteLine($"Pizza Number #{Menu[deleteNumber]} will be removed");
                Menu.Remove(deleteNumber);
            }
            else Console.WriteLine($"The Menu does not contain a pizza with {deleteNumber}");
        }
        public static void SearchMenu()
        {
            Console.WriteLine("Search by number, name or price. Enter search query: ");
            string userInput = Store.ReadYesNo();
            Console.WriteLine();
            if (string.IsNullOrEmpty(userInput))
            {
                Console.WriteLine("Invalid user input, try again");
            }
            else
            {
                bool hasBeenFound = false;
                foreach (var item in Menu)
                {
                    string tempString1 = item.Key.ToString();
                    string tempstring2 = item.Value.Name.ToLower();
                    string tempString3 = item.Value.Price.ToString();
                    if (userInput == tempString1 || userInput == tempstring2 || userInput == tempString3)
                    {
                        Console.WriteLine($"#{item.Key}, Name: {item.Value.Name}, Price: {item.Value.Price}");
                        Console.WriteLine();
                        hasBeenFound = true;
                    }
                }
                if (!hasBeenFound)
                {
                    Console.WriteLine("No results found");
                    Store.PressKeyToCont();
                }
            }
        }
        #endregion
    }
}