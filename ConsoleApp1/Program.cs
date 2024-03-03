using ClassLibrary;
using Lab9;

namespace Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Avto avto = new Avto();
            LightCar light = new LightCar();
            OffRoadCar offRoad = new OffRoadCar();
            HeavyCar heavy = new HeavyCar();

            Console.WriteLine("Создание обычного авто:");
            avto.Init();
            Console.WriteLine("Создание легкового авто:");
            light.Init();
            Console.WriteLine("Создание внедорожника:");
            offRoad.Init();
            Console.WriteLine("Создание грузовика:");
            heavy.Init();

            Console.WriteLine("\nОбъекты после инициализации:");
            avto.Show();
            light.Show();
            offRoad.Show();
            heavy.Show();

            Avto randomAvto = new Avto();
            LightCar randomLight = new LightCar();
            OffRoadCar randomOffRoad = new OffRoadCar();
            HeavyCar randomHeavy = new HeavyCar();

            randomAvto.RandomInit();
            randomLight.RandomInit();
            randomOffRoad.RandomInit();
            randomHeavy.RandomInit();

            Console.WriteLine("\nСгенерированные объекты:");
            randomAvto.Show();
            randomLight.Show();
            randomOffRoad.Show();
            randomHeavy.Show();

            Console.WriteLine("\nСравнение объектов:");
            Console.WriteLine("Объект avto равен объекту randomAvto: " + avto.Equals(randomAvto));
            Console.WriteLine("Объект light равен объекту randomLight: " + light.Equals(randomLight));
            Console.WriteLine("Объект offRoad равен объекту randomOffRoad: " + offRoad.Equals(randomOffRoad));
            Console.WriteLine("Объект heavy равен объекту randomHeavy: " + heavy.Equals(randomHeavy));

            Console.WriteLine("Для продолжения введите любое значение");
            Console.ReadKey();

            Avto[] avtos = GenerateArray();
            Console.WriteLine("Создан массив из 20 машин");

            bool isCorrect = false;
            Console.WriteLine("Введите нужный элемент массива:");
            while (!isCorrect)
            {
                isCorrect = int.TryParse(Console.ReadLine(), out int num);
                if (isCorrect && num <= 20 && num >= 0)
                {
                    Console.WriteLine("Виртуальная функция: ");
                    avtos[num].Show();
                }
                else
                {
                    Console.WriteLine("Неверное значение. Попробуйте ещё раз:");
                }
            }

            // Виртуальные функции отличаются от обычных тем, что не связаны с функциями и методами
            // с таким-же названием в классах-наследниках. Поэтому при вызове функции на объект avto,
            // который является одним из наследников класса, происходит автоматический вызов функции,
            // соответствующей классу объекта

            Console.WriteLine("Самый дорогой внедорожник:");
            ReturnMostExpensiveOddRoad(avtos).Show();

            Console.WriteLine("Проверка, являются ли элементы массива легковым автомобилем:");
            IsLightCar(avtos);

            Console.WriteLine("Все грузовики в массиве:");
            TypeOfCar(avtos);*/

            Console.WriteLine("Массив из машин и часов:");
            object[] objects = GenerateObjectsArray();
            PrintArray(objects);

            Console.WriteLine("Отсортированный массив(цена):");
            Array.Sort(objects);
            DialClock clockToFindBinary = new DialClock();
            clockToFindBinary = PrintArray(objects);

            Console.WriteLine("Поиск часов в отсортированном массиве:");
            int position = Array.BinarySearch(objects, clockToFindBinary);
            Console.WriteLine($"Позиция часов в массиве: {position}");

            Console.WriteLine("Отсортированный массив(дата выпуска):");
            Array.Sort(objects);
            clockToFindBinary = PrintArray(objects);

            Console.WriteLine("Поиск часов в отсортированном массиве:");
            position = Array.BinarySearch(objects, clockToFindBinary);
            Console.WriteLine($"Позиция часов в массиве: {position}");


            Console.WriteLine("Машина для копирования:");
            Avto avtotoClone = new Avto();
            avtotoClone.RandomInit();
            avtotoClone.Show();

            Console.WriteLine("Поверхностное копирование:");
            Avto copieddAvto = avtotoClone.ShallowCopy();
            copieddAvto.Show();

            Console.WriteLine("Клонирование:");
            Avto clonedAvto = (Avto)avtotoClone.Clone();
            clonedAvto.Show();
        }

        public static DialClock PrintArray(object[] objects)
        {
            DialClock clockToFindBinary = new DialClock();
            for (int i = 0; i < objects.Length; i++)
            {
                if (objects[i].GetType() == typeof(DialClock))
                {
                    DialClock clock = (DialClock)objects[i];
                    clock.Show();
                    clockToFindBinary = clock;
                }
                else
                {
                    Avto avtoToPrint = (Avto)objects[i];
                    avtoToPrint.Show();
                }
            }
            return clockToFindBinary;
        }

        public static Avto[] GenerateArray()
        {
            Avto[] avtos = new Avto[20];
            Random rand = new Random();
            for (int i = 0; i < 20; i++)
            {
                int num = rand.Next(3);
                if (num == 0)
                {
                    LightCar lightCar = new LightCar();
                    lightCar.RandomInit();
                    avtos[i] = lightCar;
                }
                else if (num == 1)
                {
                    OffRoadCar offRoadCar = new OffRoadCar();
                    offRoadCar.RandomInit();
                    avtos[i] = offRoadCar;
                }
                else if (num == 2)
                {
                    HeavyCar heavyCar = new HeavyCar();
                    heavyCar.RandomInit();
                    avtos[i] = heavyCar;
                }
            }
            return avtos;
        }

        public static Avto ReturnMostExpensiveOddRoad(Avto[] avtos)
        {
            int highPrice = 0;
            Avto avtoToReturn = new Avto();
            foreach (Avto avto in avtos)
            {
                if (avto is OffRoadCar)
                    {
                    if (avto.Price >= highPrice)
                    {
                        highPrice = avto.Price;
                        avtoToReturn = avto;
                    }
                }
            }
            return avtoToReturn;
        }

        public static void IsLightCar(Avto[] avtos) 
        {
            int i = 0;
            foreach (Avto avto in avtos)
            {
                LightCar lightCar = avto as LightCar;
                if (lightCar != null)
                {
                    Console.WriteLine($"Элемент {i} = True");
                }
                else
                {
                    Console.WriteLine($"Элемент {i} = False");
                }
                i++;
            }
        }

        public static void TypeOfCar(Avto[] avtos)
        {
            foreach (Avto avto in avtos)
            {
                if (avto.GetType() == typeof(HeavyCar))
                {
                    Console.WriteLine(avto);
                }
            }

        }

        public static Object[] GenerateObjectsArray()
        {
            Random rnd = new Random();
            object[] objects = new object[5];
            for (int i = 0; i < objects.Length; i++)
            {
                int num = rnd.Next(4);
                if (num == 0)
                {
                    DialClock clock = new DialClock();
                    clock.RandomInit();
                    objects[i] = clock;
                }
                else if(num == 1)
                {
                    LightCar lightCar = new LightCar();
                    lightCar.RandomInit();
                    objects[i] = lightCar;
                }
                else if (num == 2)
                {
                    OffRoadCar offRoadCar = new OffRoadCar();
                    offRoadCar.RandomInit();
                    objects[i] = offRoadCar;
                }
                else if (num == 3)
                {
                    HeavyCar heavyCar = new HeavyCar();
                    heavyCar.RandomInit();
                    objects[i] = heavyCar;
                }
            }

            return objects;
        }
    }
}