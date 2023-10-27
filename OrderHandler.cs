using System.Threading.Channels;

namespace PizzaStore
{
    class OrderHandler
    {
        public static string LogEntry { get; private set; } = "";
        public static double LogRevenue { get; private set; } = 0;
        public static List<Pizza> LogList { get; set; } = new() { };

        public OrderHandler()
        {   
            LogEntry = $"Log started at {GenerateTimeStamp()}" ?? "";
            Pizza timePizza = new(999, $"Log started at {GenerateTimeStamp()}", 0);
            LogList.Add(timePizza);
        }
        #region Method
        public static string GenerateTimeStamp()
        {
            DateTime timeNow = DateTime.Now;
            string TimeStamp = timeNow.ToString("dd-MM-yyyy HH:mm:ss");
            return TimeStamp;
        }
        public static PizzaOrder CreatOrder(Customer InputCustomer)
        {
            Customer customer = InputCustomer;
            Pizza customerPizza = AddCustomerInfoPizza(customer);
            Console.WriteLine("Creating a new order...");
            PizzaOrder pizzaOrder = new();
            pizzaOrder.AddPizza2Order();
            Console.WriteLine($"Order {pizzaOrder.OrderName} has been placed.\n");
            Console.WriteLine("Your order details:");
            pizzaOrder.ShowOrder();
            Console.WriteLine($"Total Price: {pizzaOrder.TotalPrice:F2} kr\n");
            pizzaOrder.OrderList.Add(customerPizza); 
            AddLog(pizzaOrder); // Order now include a line with customer info
            return pizzaOrder;
        }
        public static void AddLog (PizzaOrder pizzaOrder)
        {
            string TimeStamp = GenerateTimeStamp();
            LogRevenue += pizzaOrder.TotalPrice;
            LogEntry = $"{pizzaOrder.OrderName} {TimeStamp}";
            LogList.AddRange(pizzaOrder.OrderList);
            Pizza logPizza = new(999, LogEntry, LogRevenue);
            LogList.Add(logPizza);
        }
        public static Pizza AddCustomerInfoPizza(Customer InputCustomer)
        {
            Customer customer = InputCustomer;
            string memberStatus = "Member: ";
            if (customer.Member) { memberStatus += "Yes"; }
            else { memberStatus += "No"; }
            string customerInfo = $"{customer.Name}, {customer.Address}, {customer.PostalCode}-{customer.City}, {customer.PhoneNumber}, {memberStatus}";
            Pizza customerPizza = new(customer.Id, customerInfo, 0);
            return customerPizza;

            // Alternative way to work around customer ID exists, automatic default customer
            // string customerIdString = Console.ReadLine() ?? "1000"; // Default customer ID is 1000
            // int customerId = int.Parse(customerIdString);
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






//if (CustomerFile.Customers.Any(c => c.Id == customerId)) // Check if customer ID exists
//{
//    Console.WriteLine("Customer ID does not exist, please try again");
//    AddCustomerInfo();
//}

//public static string GetCustomerName()
//{
//    Console.WriteLine("Enter customer name:");
//    string customerName = Console.ReadLine() ?? string.Empty;
//    return customerName;
//}
