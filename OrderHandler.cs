namespace PizzaStore
{
    class OrderHandler
    {
        #region Instance Field
        private string _timeStamp = "";
        private string _logEntry;
        private double _logRevenue = 0;
        private List<Pizza> _logList = new List<Pizza>() { };
        #endregion

        #region Constructor
        public OrderHandler()
        {   
            _logEntry = $"Log started at {GenerateTimeStamp()}" ?? "";
            Pizza timePizza = new Pizza(999, $"Log started at {GenerateTimeStamp()}", 0);
            _logList.Add(timePizza);
        }
        #endregion

        #region Properties
        public List<Pizza> LogList
        {
            get { return _logList; }
        }
        public string LogEntry
        {
            get { return _logEntry; }
        }
        public double LogRevenue
        {
            get { return _logRevenue; }
        }
        public string TimeStamp
        {
            get { return _timeStamp; }
        }
        #endregion

        #region Method
        public string GenerateTimeStamp()
        {
            DateTime timeNow = DateTime.Now;
            _timeStamp = timeNow.ToString("dd-MM-yyyy HH:mm:ss");
            return _timeStamp;
        }
        public void CreatOrder()
        {
            Console.WriteLine("Creating a new order...");
            PizzaOrder pizzaOrder = new PizzaOrder();
            pizzaOrder.AddPizza2Order();
            Console.WriteLine($"Order {pizzaOrder.OrderName} has been placed.\n");
            Console.WriteLine("Your order details:");
            pizzaOrder.ShowOrder();
            Console.WriteLine($"Total Price: {pizzaOrder.TotalPrice:F2} kr\n");
            _logRevenue += pizzaOrder.TotalPrice;
            GenerateTimeStamp();
            _logEntry = $"{pizzaOrder.OrderName} {_timeStamp}";
            _logList.AddRange(pizzaOrder.OrderList);
            Pizza logPizza = new Pizza(999, _logEntry, _logRevenue);
            _logList.Add(logPizza);
        }
        public void ShowLog()
        {
            for (int i = 0; i < _logList.Count; i++)
            {
                Pizza? item = _logList[i];
                Console.WriteLine($"#{item.Number} - {item.Name} - {item.Price:F2} kr");
            }
            Console.WriteLine();
        }
        #endregion
    }
}

