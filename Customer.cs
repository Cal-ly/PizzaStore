using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore
{
    class Customer
    {
        private static int nextId = 100;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public Customer()
        {
            Id = 0;
            Name = "";
            Address = "";
            PostalCode = "";
            City = "";
            PhoneNumber = "";
        }
        public Customer(string name, string address, string postalCode, string city, string phoneNumber)
        {
            Id += nextId;
            Name = name;
            Address = address;
            PostalCode = postalCode;
            City = city;
            PhoneNumber = phoneNumber;
        }
    }
}
