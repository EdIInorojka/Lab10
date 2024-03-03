using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10_ClassLibrary
{
    class HeavyCar : Avto
    {
        private double carryingCapacity;   // грузоподъемность

        public HeavyCar() : base()
        {
            // конструктор без параметров
            carryingCapacity = 0;
        }

        public HeavyCar(string brand, int year, string color, double price, double groundClearance,
                            double carryingCapacity) :
            base(brand, year, color, price, groundClearance)
        {
            // конструктор с параметрами
            this.carryingCapacity = carryingCapacity;
        }

        public HeavyCar(HeavyCar heavy) : base(heavy)
        {
            // конструктор копирования
            carryingCapacity = heavy.carryingCapacity;
        }

        public double CarryingCapacity
        {
            get { return carryingCapacity; }
            set
            {
                if (value >= 0)
                    carryingCapacity = value;
                else
                    throw new ArgumentException("Грузоподъемность не может быть отрицательной.");
            }
        }

        public override void Show()
        {
            base.Show();

            Console.WriteLine("Грузоподъемность: " + carryingCapacity);
        }

        public override void Init()
        {
            base.Init();

            Console.Write("Введите грузоподъемность: ");
            carryingCapacity = double.Parse(Console.ReadLine());
        }

        public new static HeavyCar RandomInit()
        {
            HeavyCar gruzovoyAvto = (HeavyCar)Avto.RandomInit();

            Random rnd = new Random();
            gruzovoyAvto.CarryingCapacity = rnd.NextDouble() * 10000;

            return gruzovoyAvto;
        }

        public override bool Equals(object obj)
        {
            if (!base.Equals(obj))
                return false;

            HeavyCar other = (HeavyCar)obj;

            return carryingCapacity == other.carryingCapacity;
        }
    }
}
