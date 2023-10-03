using PizzaStore;

class Program
{
    private static void Main()
    {
        PizzaMenu menu = new PizzaMenu();
        OrderHandler orderHandler = new OrderHandler();
        while (true)
        {
            Console.WriteLine("Welcome to Pizza Store!");
            Console.WriteLine("1. Show the Pizza Menu");
            Console.WriteLine("2. Search the menu");
            Console.WriteLine("3. Modify the Pizza Menu");
            Console.WriteLine("4. Create a new order");
            Console.WriteLine("5. Show todays orderlog");
            Console.WriteLine("6. Exit");

            if (int.TryParse(Console.ReadLine(), out int userChoice) && userChoice <= 6)
            {
                switch (userChoice)
                {
                    case 1:
                        Console.WriteLine();
                        Console.WriteLine("Big Mamma a la Carte, Bon Appetit <3");
                        menu.ShowMenu();
                        break;
                    case 2:
                        Console.WriteLine();
                        menu.SearchMenu();
                        break;
                    case 3:
                        Console.WriteLine();
                        Console.WriteLine("Modifying the Pizza Menu...");
                        menu.AddMenuItem();
                        Console.WriteLine("Pizza Menu has been updated.");
                        break;
                    case 4:
                        Console.WriteLine();
                        menu.ShowMenu();
                        orderHandler.CreatOrder();
                        break;
                    case 5:
                        Console.WriteLine();
                        orderHandler.ShowLog();
                        break;
                    case 6:
                        Console.WriteLine();
                        Console.WriteLine("Goodbye!\n");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please choose a valid option.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please choose a valid option.");
            }
        }
    }
}