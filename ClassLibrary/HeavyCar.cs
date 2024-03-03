using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class HeavyCar : Avto
    {
        private int carryingCapacity;   // грузоподъемность

        public HeavyCar() : base()
        {
            // конструктор без параметров
            carryingCapacity = 0;
        }

        public HeavyCar(string brand, int year, string color, int price, int groundClearance,
                            int carryingCapacity) :
            base(brand, year, color, price, groundClearance)
        {
            // конструктор с параметрами
            this.CarryingCapacity = carryingCapacity;
        }

        public HeavyCar(HeavyCar heavy) : base(heavy)
        {
            // конструктор копирования
            carryingCapacity = heavy.carryingCapacity;
        }

        public int CarryingCapacity
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
            carryingCapacity = int.Parse(Console.ReadLine());
        }

        public override void RandomInit()
        {
            base.RandomInit();
            Random rnd = new Random();

            CarryingCapacity = rnd.Next(1000, 10000);
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
