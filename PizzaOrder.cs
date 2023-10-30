namespace PizzaStore
{
    class PizzaOrder
    {
        private static int nextOrderId = 1;
        public string OrderName { get; }
        public double TotalPrice { get; private set; }
        public List<Pizza> OrderList { get; set; } = new() { };

        public PizzaOrder()
        {
            OrderName = "Order #" + $"{nextOrderId}"; //Every order has now a unique ID
            nextOrderId++;
        }

        #region Method
        public void ShowOrder()
        {
            Console.WriteLine($"This is: {OrderName}");
            for (int i = 0; i < OrderList.Count; i++)
            {
                Pizza? item = OrderList[i];
                Console.WriteLine($"#{item.Number}, {item.Name}, {item.Price:F2} kr");
            }
            Console.WriteLine();
        }
        public void AddPizzaToOrder()
        {
            while (true) // Start of order
            {
                Console.Clear();
                Console.WriteLine("Do you want to add a pizza to the order? (y/n)");
                string userConsole = Store.ReadYesNo();
                userConsole?.ToLower();
                if (userConsole == "y")
                {
                    Console.WriteLine("Choose a pizza from the menu (enter a number):");
                    string userChoiceString = Store.ReadYesNo();
                    int userChoice = int.Parse(userChoiceString);
                    
                    if (PizzaMenu.Menu.ContainsKey(userChoice))
                    {
                        Pizza tempPizza = new()  
                        {
                            Number = PizzaMenu.Menu[userChoice].Number,
                            Name = PizzaMenu.Menu[userChoice].Name,
                            Price = PizzaMenu.Menu[userChoice].Price
                        }; // Create a placeholder Pizza object and fills it with the chosen pizza from the menu
                        
                        Console.WriteLine("Do you want to add toppings to this pizza? (y/n)");
                        string addToppingsChoice = Store.ReadYesNo();
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
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please choose a valid option.");
                }
            }
        }
        #endregion
    }
}
