namespace client
{
    public class Client
    {
        public string FirstName;
        public string LastName;
        private double _weight;
        private double _height;

        public Client()
        {
            FirstName = "XXXX";
            LastName = "YYYY";
            _height = 0;
            _weight = 0;
        }

        public Client(string firstName, string lastName, double weight, double height)
        {
            FirstName = firstName;
            LastName = lastName;
            _weight = weight;
            _height = height;
        }

        public double BmiScore => _weight / (Math.Pow(_height, 2)) * 703;

        public string BmiStatus
        {
            get
            {
                double bmi = BmiScore;
                if (bmi <= 18.4)
                    return "Underweight";
                else if (bmi <= 24.9)
                    return "Normal";
                else if (bmi <= 29.9)
                    return "Overweight";
                else
                    return "Obese";
            }
        }

        public string FullName => $"{LastName}, {FirstName}";

        public double Weight
        {
            get { return _weight; }
            set
            {
                if (value < 0.0)
                    throw new ArgumentException("Weight must be a positive value (0 or greater)");
                _weight = value;
            }
        }

        public double Height
        {
            get { return _height; }
            set
            {
                if (value < 0.0)
                    throw new ArgumentException("Height must be a positive value (0 or greater)");
                _height = value;
            }
        }
    }
}
