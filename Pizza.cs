namespace PizzaStore
{
    class Pizza
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public Pizza(int number, string name, double price)
        {
            Number = number;
            Name = name;
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
