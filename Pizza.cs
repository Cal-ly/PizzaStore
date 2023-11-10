namespace PizzaStore
{
    public class Pizza
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public Pizza()
        {
            Number = 0;
            Name = "DefaultPizza";
            Price = 0;
        }

        public Pizza(int NumberInput, string NameInput, double PriceInput)
        {
            if (NumberInput < 0)
            {
                throw new ArgumentException("Number must be a positive integer.");
            }
            Number = NumberInput;

            if (string.IsNullOrEmpty(NameInput))
            {
                throw new ArgumentException("Name cannot be null or empty.");
            }
            Name = NameInput;

            if (PriceInput < 0)
            {
                throw new ArgumentException("Price cannot be negative.");
            }
            Price = PriceInput;
        }
        public override string ToString()
        {
            return $"{{{nameof(Number)}={Number}, {nameof(Name)}={Name}, {nameof(Price)}={Price}}}";
        }
    }
}
