namespace PizzaStore
{
    public class Pizza
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public Pizza(int number, string name, double price)
        {
            if (number < 0 || !int.TryParse(number.ToString(), out int result))
            {
                throw new ArgumentException("Invalid input. Number must be a positive integer.");
            }
            Number = number;

            if (name.Length > 40)
            {
                throw new ArgumentException("Invalid input. Name must be less than or equal to 40 characters.");
            }
            Name = name;

            if (price < 0)
            {
                throw new ArgumentException("Invalid input. Price must be a positive number.");
            }
            Price = price;
        }
        public Pizza()
        {
            Number = 0;
            Name = "DefaultPizza";
            Price = 0;
        }
        public override string ToString()
        {
            return $"{{{nameof(Number)}={Number}, {nameof(Name)}={Name}, {nameof(Price)}={Price}}}";
        }
    }
}
