namespace PizzaStore
{
    class OrderHandler
    {
        public string TimeStamp { get; private set; } = "";
        public string LogEntry { get; set; } = "";
        public double LogRevenue { get; set; } = 0;
        public static List<Pizza> LogList { get; set; } = new() { };

        public OrderHandler()
        {   
            LogEntry = $"Log started at {GenerateTimeStamp()}" ?? "";
            Pizza timePizza = new(999, $"Log started at {GenerateTimeStamp()}", 0);
            LogList.Add(timePizza);
        }

        #region Method
        public string GenerateTimeStamp()
        {
            DateTime timeNow = DateTime.Now;
            TimeStamp = timeNow.ToString("dd-MM-yyyy HH:mm:ss");
            return TimeStamp;
        }
        public void CreatOrder()
        {
            Console.WriteLine("Creating a new order...");
            PizzaOrder pizzaOrder = new();
            pizzaOrder.AddPizza2Order();
            Console.WriteLine($"Order {pizzaOrder.OrderName} has been placed.\n");
            Console.WriteLine("Your order details:");
            pizzaOrder.ShowOrder();
            Console.WriteLine($"Total Price: {pizzaOrder.TotalPrice:F2} kr\n");
            LogRevenue += pizzaOrder.TotalPrice;
            GenerateTimeStamp();
            LogEntry = $"{pizzaOrder.OrderName} {TimeStamp}";
            LogList.AddRange(pizzaOrder.OrderList);
            Pizza logPizza = new(999, LogEntry, LogRevenue);
            LogList.Add(logPizza);
        }
        public static void ShowLog()
        {
            for (int i = 0; i < LogList.Count; i++)
            {
                Pizza? item = LogList[i];
                Console.WriteLine($"#{item.Number} - {item.Name} - {item.Price:F2} kr");
            }
            Console.WriteLine();
        }
        #endregion
    }
}

