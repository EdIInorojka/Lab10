using System;

class Avto
{
    protected string brand;       // бренд
    protected int year;           // год выпуска
    protected string color;       // цвет
    protected double price;       // стоимость
    protected double groundClearance;  // дорожный просвет

    public Avto()
    {
        // конструктор без параметров
        brand = "";
        year = 0;
        color = "";
        price = 0;
        groundClearance = 0;
    }

    public Avto(string brand, int year, string color, double price, double groundClearance)
    {
        // конструктор с параметрами
        this.brand = brand;
        this.year = year;
        this.color = color;
        this.price = price;
        this.groundClearance = groundClearance;
    }

    public Avto(Avto avto)
    {
        // конструктор копирования
        brand = avto.brand;
        year = avto.year;
        color = avto.color;
        price = avto.price;
        groundClearance = avto.groundClearance;
    }

    public string Brand
    {
        get { return brand; }
        set { brand = value; }
    }

    public int Year
    {
        get { return year; }
        set { year = value; }
    }

    public string Color
    {
        get { return color; }
        set { color = value; }
    }

    public double Price
    {
        get { return price; }
        set
        {
            if (value >= 0)
                price = value;
            else
                throw new ArgumentException("Стоимость не может быть отрицательной.");
        }
    }

    public double GroundClearance
    {
        get { return groundClearance; }
        set
        {
            if (value >= 0)
                groundClearance = value;
            else
                throw new ArgumentException("Дорожный просвет не может быть отрицательным.");
        }
    }

    public virtual void Show()
    {
        Console.WriteLine("Бренд: " + brand);
        Console.WriteLine("Год выпуска: " + year);
        Console.WriteLine("Цвет: " + color);
        Console.WriteLine("Стоимость: " + price);
        Console.WriteLine("Дорожный просвет: " + groundClearance);
    }

    public virtual void Init()
    {
        Console.Write("Введите бренд: ");
        brand = Console.ReadLine();

        Console.Write("Введите год выпуска: ");
        year = int.Parse(Console.ReadLine());

        Console.Write("Введите цвет: ");
        color = Console.ReadLine();

        Console.Write("Введите стоимость: ");
        price = double.Parse(Console.ReadLine());

        Console.Write("Введите дорожный просвет: ");
        groundClearance = double.Parse(Console.ReadLine());
    }

    public static Avto RandomInit()
    {
        Random rnd = new Random();

        string[] brands = { "Audi", "BMW", "Mercedes", "Chevrolet", "Ford" };
        int brandIndex = rnd.Next(brands.Length);
        string brand = brands[brandIndex];

        int year = rnd.Next(1990, 2023);

        string[] colors = { "Красный", "Синий", "Зеленый", "Белый", "Черный" };
        int colorIndex = rnd.Next(colors.Length);
        string color = colors[colorIndex];

        double price = rnd.NextDouble() * 100000;

        double groundClearance = rnd.NextDouble() * 30;

        return new Avto(brand, year, color, price, groundClearance);
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        Avto other = (Avto)obj;

        return brand == other.brand &&
               year == other.year &&
               color == other.color &&
               price == other.price &&
               groundClearance == other.groundClearance;
    }
}


