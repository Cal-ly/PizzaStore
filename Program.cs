using PizzaStore;
class Program
{
    private static void Main()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Title = "Pizza Store";
        Console.Beep();
        Store.RunStore();
    }
}