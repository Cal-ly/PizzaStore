namespace PizzaStore
{
    class PizzaMenu
    {
        #region Instance Field
        Pizza pizza1 = new Pizza(1, "Margherita", 101.00);
        Pizza pizza2 = new Pizza(2, "Vesuvio", 102.00);
        Pizza pizza3 = new Pizza(3, "Capricciosa", 103.00);
        Pizza pizza4 = new Pizza(4, "Calzone", 104.00);
        public List<Pizza> _menuList = new List<Pizza>() { };

        #endregion

        #region Constrctor 
        public PizzaMenu()
        {
            _menuList.Add(pizza1);
            _menuList.Add(pizza2);
            _menuList.Add(pizza3);
            _menuList.Add(pizza4);
            // Initialize the MenuList property in the constructor -> can be further hardcoded, if not amended while program runs
        }
        #endregion

        #region Properties
        public List<Pizza> MenuList
        {
            get { return _menuList; }
        }
        #endregion

        #region Methods
        public void ShowMenu()
        {
            for (int i = 0; i < _menuList.Count; i++)
            {
                Pizza item = _menuList[i];
                Console.WriteLine($"#{item.Number} - {item.Name} - {item.Price:F2} kr");
            }
            Console.WriteLine();
        }
        public void AddMenuItem()

        {
            Console.WriteLine("Type a list number for the new pizza:\nBe aware that any existing items with that list number will be overwritten");
            if (int.TryParse(Console.ReadLine(), out int entryNum))
            {
                Console.WriteLine("Type name for the new pizza:");
                string entryName = Console.ReadLine() ?? ""; // null-coalescing operator, if !null, then left side gets returned, otherwise reverse, in this case, an empty string
                Console.WriteLine("Type price for the new pizza:");
                if (double.TryParse(Console.ReadLine(), out double entryPrice) && entryPrice >= 0)
                {
                    entryPrice = Math.Round(entryPrice, 2); // Round the price and update entryPrice

                    // Update or add the new entry to the menu list
                    bool entryExists = false;
                    for (int i = 0; i < _menuList.Count; i++)
                    {
                        if (_menuList[i].Number == entryNum)
                        {
                            Console.WriteLine("The entry exists and will be overwritten");
                            Console.WriteLine("Press 1 to continue, Press 2 to cancel");
                            bool v = int.TryParse(Console.ReadLine(), out int overWrite);
                            if (v == true && overWrite == 1)
                            {
                                _menuList.Insert(i, new Pizza(entryNum, entryName, entryPrice));
                                entryExists = true;
                                break;
                            }
                            else if (v == true && overWrite != 1)
                            {
                                Console.WriteLine("New menu entry has been canceled");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid entry, try again");
                            }
                        }
                    }

                    if (!entryExists)
                    {
                        _menuList.Add(new Pizza(entryNum, entryName, entryPrice));
                    }

                    Console.WriteLine("New menu item added successfully.");
                }
                else
                {
                    Console.WriteLine("Invalid price input. Please enter a valid positive number.");
                }
            }
            else
            {
                Console.WriteLine("Invalid list number input. Please enter a valid integer.");
            }
        }
        public void SearchMenu()
        {
            Console.WriteLine("Enter search query: ");
            string userInput = Console.ReadLine() ?? string.Empty;

            foreach (Pizza item in _menuList)
            {
                string tempString1 = item.Number.ToString();
                string tempstring2 = item.Name;
                string tempString3 = item.Price.ToString();
                if (userInput == tempString1 || userInput == tempstring2 || userInput == tempString3)
                {
                    Console.WriteLine($" #{item.Number}, Name: {item.Name}, Price: {item.Price}");
                }
                
            }
        }
        #endregion
    }
}