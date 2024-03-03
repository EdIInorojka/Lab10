using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10_ClassLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            Avto avto = new Avto();
            LightCar light = new LightCar();
            OffRoadCar offroad = new OffRoadCar();
            HeavyCar heavy = new HeavyCar();

            avto.Init();
            light.Init();
            offroad.Init();
            heavy.Init();

            Console.WriteLine("\nОбъекты после инициализации:");
            avto.Show();
            light.Show();
            offroad.Show();
            heavy.Show();

            Avto randomAvto = Avto.RandomInit();
            LightCar randomLight = LightCar.RandomInit();
            OffRoadCar randomOffRoad = OffRoadCar.RandomInit();
            HeavyCar randomHeavy = HeavyCar.RandomInit();

            Console.WriteLine("\nСгенерированные объекты:");
            randomAvto.Show();
            randomLight.Show();
            randomOffRoad.Show();
            randomHeavy.Show();

            Console.WriteLine("\nСравнение объектов:");
            Console.WriteLine("Объект avto равен объекту randomAvto: " + avto.Equals(randomAvto));
            Console.WriteLine("Объект light равен объекту randomLight: " + light.Equals(randomLight));
            Console.WriteLine("Объект offroad равен объекту randomOffRoad: " + offroad.Equals(randomOffRoad));
            Console.WriteLine("Объект heavy равен объекту randomHeavy: " + heavy.Equals(randomHeavy));

            Console.ReadKey();
        }
    }
}
