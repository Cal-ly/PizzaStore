using PizzaStore;

class Program
{
    private static void Main()
    {
        OrderHandler orderHandler = new OrderHandler();
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out int userChoice) && userChoice <= 6)
            {
                switch (userChoice)
                {
                    case 1:
                        Console.WriteLine();
                        Console.WriteLine("Big Mamma a la Carte, Bon Appetit <3");
                        PizzaMenu.ShowMenu();
                        break;
                    case 2:
                        Console.WriteLine();
                        PizzaMenu.SearchMenu();
                        break;
                    case 3:
                        Console.WriteLine();
                        Console.WriteLine("Modifying the Pizza Menu...");
                        PizzaMenu.AddMenuItem();
                        Console.WriteLine("Pizza Menu has been updated.");
                        break;
                    case 4:
                        Console.WriteLine();
                        PizzaMenu.ShowMenu();
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