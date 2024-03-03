using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10_ClassLibrary
{
    class OffRoadCar : Avto
    {
        private bool allWheelDrive;     // полный привод
        private string offRoadType;     // тип бездорожья

        public OffRoadCar() : base()
        {
            // конструктор без параметров
            allWheelDrive = false;
            offRoadType = "";
        }

        public OffRoadCar(string brand, int year, string color, double price, double groundClearance,
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

        public new static OffRoadCar RandomInit()
        {
            OffRoadCar vnedorozhnik = (OffRoadCar)Avto.RandomInit();

            Random rnd = new Random();
            vnedorozhnik.AllWheelDrive = (rnd.Next(2) == 0);
            vnedorozhnik.OffRoadType = (vnedorozhnik.allWheelDrive ? "Полноценный" : "Легкое");

            return vnedorozhnik;
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
