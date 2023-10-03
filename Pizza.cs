namespace PizzaStore
{
    class Pizza
    {
        #region Instance Field
        private int _number;
        private string _name;
        private double _price;
        #endregion

        #region Constructor
        public Pizza(int Number, string Name, double Price)
        {
            if (Number < 0)
            {
                throw new ArgumentException("Number must be a positive integer.");
            }

            if (string.IsNullOrEmpty(Name))
            {
                throw new ArgumentException("Name cannot be null or empty.");
            }

            if (Price < 0)
            {
                throw new ArgumentException("Price cannot be negative.");
            }

            _number = Number;
            _name = Name;
            _price = Price;
        }
        #endregion

        #region Properties

        public int Number
        {
            get { return _number; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Number must be a positive integer.");
                }
                _number = value;
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or empty.");
                }
                _name = value;
            }
        }

        public double Price
        {
            get { return _price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price cannot be negative.");
                }
                _price = value;
            }
        }
        #endregion

        #region Methods
        //No Methods
        #endregion
    }
}
