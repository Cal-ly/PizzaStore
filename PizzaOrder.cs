namespace PizzaStore
{
    class PizzaOrder
    {
        #region Instance Fields
        private static int nextOrderId = 1;
        public string OrderName { get; }
        public double TotalPrice { get; private set; }
        public List<Pizza> OrderList { get; } = new List<Pizza>() { };
        #endregion

        #region Constructor
        public PizzaOrder()
        {
            OrderName = "Order #" + $"{nextOrderId}"; //Every order has now a unique ID
            nextOrderId++;
        }
        #endregion

        #region Method
        //public static int GenerateOrderId()
        //{
        //    nextOrderId++;
        //    return nextOrderId;
        //}
        public void ShowOrder()
        {
            Console.WriteLine($"This is: {OrderName}");
            for (int i = 0; i < OrderList.Count; i++)
            {
                Pizza? item = OrderList[i];
                Console.WriteLine($"#{item.Number}, {item.Name}, {item.Price:F2} kr");
            }
        }

        public void AddPizza2Order()
        {
            while (true) // Start of order
            {
                Console.WriteLine("Do you want to add a pizza to the order? (y/n)");
                string userConsole = Console.ReadLine() ?? string.Empty;
                userConsole?.ToLower();
                if (userConsole == "y")
                {
                    Console.WriteLine("Choose a pizza from the menu (enter a number):");
                    string userChoiceString = Console.ReadLine() ?? string.Empty;
                    int userChoice = int.Parse(userChoiceString);
                    
                    if (PizzaMenu.Menu.ContainsKey(userChoice))
                    {
                        Pizza tempPizza = new()  
                        {
                            Number = PizzaMenu.Menu[userChoice].Number,
                            Name = PizzaMenu.Menu[userChoice].Name,
                            Price = PizzaMenu.Menu[userChoice].Price
                        }; // Create a placeholder Pizza object and fills ir with the chosen pizza from the menu
                        
                        Console.WriteLine("Do you want to add toppings to this pizza? (y/n)");
                        string addToppingsChoice = Console.ReadLine() ?? string.Empty;
                        addToppingsChoice?.ToLower();

                        if (addToppingsChoice == "y")
                        {
                            bool loopCondition = true;
                            while (loopCondition)
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
                            }
                        }
                        else if (addToppingsChoice == "n")
                        {
                            Console.WriteLine("No extra topping wanted");
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please choose a valid option.");
                        }
                        OrderList.Add(tempPizza); // Add the pizza to the order
                        TotalPrice += tempPizza.Price; // Add total single pizzacost to totalPrice
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please choose a valid option.");
                    }
                }
                else if (userConsole == "n")
                {
                    //GenerateOrderId();
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please choose a valid option.");
                }

            } //while (true); // End of order
        }
        #endregion
    }
}
