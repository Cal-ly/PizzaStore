namespace PizzaStore
{
    class PizzaOrder
    {
        #region Instance Fields
        private static int _nextOrderId = 1;
        private string _orderName;
        private double _totalPrice;
        private List<Pizza> _orderList = new List<Pizza>() { };
        #endregion

        #region Constructor
        public PizzaOrder()
        {
            _orderName = "Order #" + $"{_nextOrderId}"; //Every order has now a unique ID
        }
        #endregion

        #region Properties
        public List<Pizza> OrderList
        {
            get { return _orderList; }
        }

        public string OrderName
        {
            get { return _orderName; }
        }

        public double TotalPrice
        {
            get { return _totalPrice; }
        }
        #endregion

        #region Method
        public static int GenerateOrderId()
        {
            _nextOrderId++;
            return _nextOrderId;
        }
        public void ShowOrder()
        {
            Console.WriteLine($"Order Name: {_orderName}");
            for (int i = 0; i < _orderList.Count; i++)
            {
                Pizza? item = _orderList[i];
                Console.WriteLine($"#{item.Number}, {item.Name}, {item.Price:F2} kr");
            }
        }

        public void AddPizza2Order()
        {
            // Create a PizzaMenu to choose from
            PizzaMenu menu = new PizzaMenu();
            do
            {
                Console.WriteLine("Do you want to add a pizza to the order? (y/n)");
                string userConsole = Console.ReadLine() ?? string.Empty;
                userConsole.ToLower();
                if (userConsole == "y")
                {
                    Console.WriteLine("Choose a pizza from the menu (enter a number):");
                    string userChoiceString = Console.ReadLine() ?? string.Empty;
                    int userChoice = int.Parse(userChoiceString);
                    Pizza tempPizza = new Pizza(0, "New Order", 1); // Create a placeholder Pizza object
                    if (userChoice >= 1 && userChoice <= menu.MenuList.Count)
                    {
                        int subs = 1;
                        int index = userChoice - subs; // Adjust for zero-based index
                        tempPizza.Number = menu.MenuList[index].Number;
                        tempPizza.Name = menu.MenuList[index].Name;
                        tempPizza.Price = menu.MenuList[index].Price;
                        // Sends the "menu values" to placeholder object

                        // Ask the user if they want to add toppings
                        Console.WriteLine("Do you want to add toppings to this pizza? (1 for Yes, 2 for No)");
                        bool v1 = int.TryParse(Console.ReadLine(), out int addToppingsChoice);

                        if (v1 == true && addToppingsChoice == 1)
                        {
                            bool loopCondition = true;
                            do
                            {
                                Console.WriteLine("Choose a topping to add:");
                                Console.WriteLine("1. Mushrooms (+10.00 kr)");
                                Console.WriteLine("2. Anchovies (+10.00 kr)");
                                Console.WriteLine("3. No additional topping");

                                if (int.TryParse(Console.ReadLine(), out int userChoice2))
                                {
                                    switch (userChoice2)
                                    {
                                        case 1:
                                            tempPizza.Name += " + mushrooms";
                                            tempPizza.Price += 10.00;
                                            break;
                                        case 2:
                                            tempPizza.Name += " + anchovies";
                                            tempPizza.Price += 10.00;
                                            break;
                                        case 3:
                                            loopCondition = false;
                                            break;
                                        default:
                                            Console.WriteLine("Invalid input. Please choose a valid option.");
                                            break;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input. Please choose a valid option.");
                                }
                            } while (loopCondition);
                        }
                        _orderList.Add(tempPizza); // Add the pizza to the order
                        _totalPrice += tempPizza.Price; // Add total single pizzacost to totalPrice
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please choose a valid option.");
                    }
                }
                else if (userConsole == "n")
                {
                    GenerateOrderId();
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please choose a valid option.");
                }

            } while (true); // End of order
        }
        #endregion
    }
}
