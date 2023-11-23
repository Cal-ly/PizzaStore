namespace PizzaStore.Tests
{
    [TestClass()]
    public class PizzaMenuTests
    {
        [TestMethod()]
        public void ShowMenuTest()
        {
            // Arrange
            StringWriter sw = new();
            Console.SetOut(sw);

            // Act
            PizzaMenu.ShowMenu();

            // Assert
            string testString = sw.ToString();
            string forExpectedOutput = "Big Mamma a la Carte, Bon Appetit <3\n";
            foreach (var item in PizzaMenu.Menu)
            {
                forExpectedOutput += $"#{item.Key} - {item.Value.Name} - {item.Value.Price:F2} kr\n";
            }

            Assert.AreEqual(forExpectedOutput.Trim(), testString.Trim());
        }

        [TestMethod()]
        public void AddMenuItemTest()
        {
            // Arrange
            StringWriter sw = new();
            Console.SetOut(sw);

            // Simulate user input for testing
            Console.SetIn(new StringReader("7\nTestPizza\n400\n"));

            // Act
            PizzaMenu.AddMenuItem();

            // Assert
            Assert.IsTrue(PizzaMenu.Menu.ContainsKey(7));
            Assert.AreEqual("TestPizza", PizzaMenu.Menu[7].Name);
            Assert.AreEqual(400, PizzaMenu.Menu[7].Price);
        }

        [TestMethod()]
        public void DeleteMenuItemTest()
        {
            // Arrange
            int itemToDelete = 3;

            // Act
            PizzaMenu.DeleteMenuItem(itemToDelete);

            // Assert
            Assert.IsFalse(PizzaMenu.Menu.ContainsKey(itemToDelete));
        }

        [TestMethod()]
        public void SearchMenuTest()
        {
            // Arrange
            StringWriter sw = new();
            Console.SetOut(sw);

            // Simulate user input for testing
            Console.SetIn(new StringReader("Vesuvio\n"));

            // Act
            PizzaMenu.SearchMenu();

            // Assert
            string expectedOutput = "Search by number, name or price. Enter search query: \r\n\r\n#2, Name: Vesuvio, Price: 102";
            Assert.AreEqual(expectedOutput, sw.ToString().Trim());



            //string expectedOutput = "#2, Name: Vesuvio, Price: 102.00\n\n";
        }
    }
}