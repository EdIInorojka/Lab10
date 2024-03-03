namespace Lab10_ClassLibrary
{
    class LightCar : Avto
    {
        private int seats;              // количество мест
        private int maxSpeed;           // максимальная скорость

        public LightCar() : base()
        {
            // конструктор без параметров
            seats = 0;
            maxSpeed = 0;
        }

        public LightCar(string brand, int year, string color, double price, double groundClearance, int seats, int maxSpeed) :
            base(brand, year, color, price, groundClearance)
        {
            // конструктор с параметрами
            this.seats = seats;
            this.maxSpeed = maxSpeed;
        }

        public LightCar(LightCar light) : base(light)
        {
            // конструктор копирования
            seats = light.seats;
            maxSpeed = light.maxSpeed;
        }

        public int Seats
        {
            get { return seats; }
            set
            {
                if (value > 0)
                    seats = value;
                else
                    throw new ArgumentException("Количество мест должно быть больше нуля.");
            }
        }

        public int MaxSpeed
        {
            get { return maxSpeed; }
            set
            {
                if (value > 0)
                    maxSpeed = value;
                else
                    throw new ArgumentException("Максимальная скорость должна быть больше нуля.");
            }
        }

        public override void Show()
        {
            base.Show();

            Console.WriteLine("Количество мест: " + seats);
            Console.WriteLine("Максимальная скорость: " + maxSpeed);
        }

        public override void Init()
        {
            base.Init();

            Console.Write("Введите количество мест: ");
            seats = int.Parse(Console.ReadLine());

            Console.Write("Введите максимальную скорость: ");
            maxSpeed = int.Parse(Console.ReadLine());
        }

        public new static LightCar RandomInit()
        {
            Random rnd = new Random();
            LightCar legkovoy = (LightCar)Avto.RandomInit();

            legkovoy.Seats = rnd.Next(2, 6);
            legkovoy.MaxSpeed = rnd.Next(100, 301);

            return legkovoy;
        }

        public override bool Equals(object obj)
        {
            if (!base.Equals(obj))
                return false;

            LightCar other = (LightCar)obj;

            return seats == other.seats &&
                   maxSpeed == other.maxSpeed;
        }
    }
}
