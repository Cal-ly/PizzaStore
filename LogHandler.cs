using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore
{
    class LogHandler
    {
        public string LogEntry { get; set; } = "";
        public static List<Customer> CustomerLogList { get; set; } = new() { };
        public LogHandler()
        {
            LogEntry = $"Log started at {OrderHandler.GenerateTimeStamp()}" ?? "";
            Customer startCustomer = new($"Log started at {OrderHandler.GenerateTimeStamp()}", "", "", "", "", true);
            CustomerLogList.Add(startCustomer);
        }

        public static 
    }
}
