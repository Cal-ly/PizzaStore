namespace PizzaStore.Tests
{
    [TestClass()]
    public class CustomerFileTests
    {
        [TestMethod()]
        public void AddCustomerTest()
        {
            // Arrange
            Customer customer1 = new Customer("John Test1", "Testvej 123", "4000", "Testkilde", "12345678", false);
            Customer customer2 = new Customer("John Test2", "Testvej 123", "4000", "Testkilde", "12345678", true);

            // Act
            CustomerFile.Customers.Add(customer1);
            using (StringReader sr = new StringReader("John Test2\nTestvej 123\n4000\nTestkilde\n12345678\ntrue\n"))
            {
                Console.SetIn(sr);
                CustomerFile.AddCustomer();
            }

            // Assert - assert that both customers are in the list
            Assert.IsTrue(CustomerFile.Customers.Any(c => c.Name == "John Test1"));
            Assert.IsTrue(CustomerFile.Customers.Any(c => c.Name == "John Test2"));
        }

        [TestMethod()]
        public void ShowCustomersTest()
        {
            // Arrange
            CustomerFile.Customers.Clear();
            Customer customer1 = new Customer("John Test1", "Testvej 123", "4000", "Testkilde", "12345678", false);
            Customer customer2 = new Customer("John Test2", "Testvej 123", "4000", "Testkilde", "12345678", true);
            CustomerFile.Customers.Add(customer1);
            CustomerFile.Customers.Add(customer2);

            // Act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                CustomerFile.ShowCustomers();
                string expectedOutput = "Customer list:\r\n" +
                                        $"{customer1}\r\n" +
                                        $"{customer2}\r\n" +
                                        "\r\n";
                string actualOutput = sw.ToString();
                Assert.AreEqual(expectedOutput, actualOutput);
            }
        }

        [TestMethod()]
        public void UpdateCustomerTest()
        {
            // Arrange
            CustomerFile.Customers.Clear();
            Customer customer1 = new("John Test1", "Testvej 123", "4000", "Testkilde", "12345678", false);
            Customer customer2 = new("John Test2", "Testvej 123", "4000", "Testkilde", "12345678", true);
            CustomerFile.Customers.Add(customer1);
            CustomerFile.Customers.Add(customer2);
            customer1.Id = 9999;

            // Act
            using (StringReader sr = new($"9999\ny\nJohn Test Updated\nn\nn\nn\nn\nn"))
            {
                Console.SetIn(sr);
                CustomerFile.UpdateCustomer();
            }

            // Assert
            string nameExpected = "John Test Updated";
            string customerName = CustomerFile.Customers.FirstOrDefault(c => c.Id == 9999)?.Name ?? string.Empty;
            Assert.AreEqual(nameExpected.Trim(), customerName.Trim());
        }

        [TestMethod()]
        public void DeleteCustomerTest()
        {
            // Arrange
            Customer customer1 = new Customer("John Test1", "Testvej 123", "4000", "Testkilde", "12345678", false);
            Customer customer2 = new Customer("John Test2", "Testvej 123", "4000", "Testkilde", "12345678", true);
            CustomerFile.Customers.Add(customer1);
            CustomerFile.Customers.Add(customer2);

            // Act
            using (StringReader sr = new StringReader($"{customer1.Id}\n"))
            {
                Console.SetIn(sr);
                CustomerFile.DeleteCustomer();
            }

            // Assert
            Assert.IsFalse(CustomerFile.Customers.Any(c => c.Id == customer1.Id));
            Assert.IsTrue(CustomerFile.Customers.Any(c => c.Id == customer2.Id));
        }

        [TestMethod()]
        public void FindCustomerTest()
        {
            // Arrange
            Customer customer1 = new Customer("John Test1", "Testvej 123", "4000", "Testkilde", "12345678", false);
            Customer customer2 = new Customer("John Test2", "Testvej 123", "4000", "Testkilde", "12345678", true);
            CustomerFile.Customers.Add(customer1);
            CustomerFile.Customers.Add(customer2);

            // Act
            Customer foundCustomer = CustomerFile.FindCustomer(customer1.Id);

            // Assert
            Assert.AreEqual(customer1, foundCustomer);
        }
    }
}