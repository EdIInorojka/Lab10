namespace ClassLibrary
{
    public class OffRoadCar : Avto
    {
        private bool allWheelDrive;     // полный привод
        private string offRoadType;     // тип бездорожья

        public OffRoadCar() : base()
        {
            // конструктор без параметров
            allWheelDrive = false;
            offRoadType = "";
        }

        public OffRoadCar(string brand, int year, string color, int price, int groundClearance,
                            bool allWheelDrive, string offRoadType) :
            base(brand, year, color, price, groundClearance)
        {
            // конструктор с параметрами
            this.allWheelDrive = allWheelDrive;
            this.offRoadType = offRoadType;
        }

        public OffRoadCar(OffRoadCar offRoad) : base(offRoad)
        {
            // конструктор копирования
            allWheelDrive = offRoad.allWheelDrive;
            offRoadType = offRoad.offRoadType;
        }

        public bool AllWheelDrive
        {
            get { return allWheelDrive; }
            set { allWheelDrive = value; }
        }

        public string OffRoadType
        {
            get { return offRoadType; }
            set { offRoadType = value; }
        }

        public override void Show()
        {
            base.Show();

            Console.WriteLine("Полный привод: " + (allWheelDrive ? "Да" : "Нет"));
            Console.WriteLine("Тип бездорожья: " + offRoadType);
        }

        public override void Init()
        {
            base.Init();

            Console.Write("Введите наличие полного привода (Y/N): ");
            allWheelDrive = (Console.ReadLine().ToUpper() == "Y");

            Console.Write("Введите тип бездорожья: ");
            offRoadType = Console.ReadLine();
        }

        public virtual void RandomInit()
        {
            base.RandomInit();
            Random rnd = new Random();

            allWheelDrive = (rnd.Next(2) == 0);
            offRoadType = (allWheelDrive ? "Полноценный" : "Легкое");
        }

        public override bool Equals(object obj)
        {
            if (!base.Equals(obj))
                return false;

            OffRoadCar other = (OffRoadCar)obj;

            return allWheelDrive == other.allWheelDrive &&
                   offRoadType == other.offRoadType;
        }
    }
}
