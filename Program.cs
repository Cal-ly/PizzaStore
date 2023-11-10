namespace PizzaStore
{
    public static class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.Default;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Title = "Pizza Store";
            Console.Beep();
            Store.RunStore();
        }
    }
}