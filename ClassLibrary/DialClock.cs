

using ClassLibrary;

namespace Lab9
{
    public class DialClock : IInit
    {
        private int hours;
        private int minutes;

        public int Hours
        {
            get { return hours; }

            set 
            { 
                if (value < 0)
                {
                    hours = 12 - Math.Abs(value) % 12;
                }
                else
                {
                    hours = value % 12;
                }
            }
        }

        public int Minutes
        {
            get { return minutes; }
            set 
            {
                if (value < 0)
                {
                    Minutes = 60 - Math.Abs(value) % 60;
                    Hours -= (int)Math.Ceiling(Math.Abs(value) / 60.0);
                }
                else 
                {
                    minutes = value % 60;
                    Hours += value / 60;
                }
            }

        }
        private static int count = 0;

        public DialClock()
        {
            hours = 0;
            minutes = 0;
            count++;
        }

        public DialClock(int hours, int minutes)
        {
            this.Hours = hours;
            this.Minutes = minutes;
            count++;
        }

        public DialClock(DialClock otherClock)
        {
            hours = otherClock.hours;
            minutes = otherClock.minutes;
            count++;
        }

        public virtual void Init()
        {
            Console.WriteLine("Введите значение часов");
            bool IsCorrect = false;
            while (!IsCorrect) 
            { 
                IsCorrect = int.TryParse(Console.ReadLine(), out int hoursValue);
                if (IsCorrect)
                {
                    Hours = hoursValue;
                    IsCorrect = true;
                }
                else
                {
                    Console.WriteLine("Неправильное значение");
                }
            }
            Console.WriteLine("Введите значение минут");
            IsCorrect = false;
            while (!IsCorrect)
            {
                IsCorrect = int.TryParse(Console.ReadLine(), out int minutesValue);
                if (IsCorrect)
                {
                    Minutes = minutesValue;
                    IsCorrect = true;
                }
                else
                {
                    Console.WriteLine("Неправильное значение");
                }
            }
        }

        public virtual void RandomInit()
        {
            Random rand = new Random();
            hours = rand.Next(0, 12);
            minutes = rand.Next(0, 60);
        }

        public static DialClock operator ++(DialClock clock)
        {
            clock.Minutes++;
            return clock;
        }

        public static DialClock operator --(DialClock clock)
        {
            clock.Minutes--;
            return clock;
        }

        public double CalculateAngle()
        {
            double hourAngle = (Hours % 12 + Minutes / 60.0) * 30;
            double minuteAngle = Minutes * 6;
            double angle = Math.Abs(hourAngle - minuteAngle);
            return Math.Round(angle, 4)%180;
        }

        public static double CalculateAngleStatic(int hours, int minutes)
        {
            if (minutes< 0)
            {
                hours -= (int)Math.Ceiling(Math.Abs(minutes) / 60.0);
                hours = hours % 12;
                minutes = 60 - (Math.Abs(minutes) % 60);
            }
            else if(minutes >= 60)
            {
                hours += minutes / 60;
                minutes = minutes % 60;
            }
            else
            {
                minutes = minutes % 60;
                hours = hours % 12;
            }

            double hourAngle = (hours % 12 + minutes / 60.0) * 30;
            double minuteAngle = minutes * 6;
            double angle = Math.Abs(hourAngle - minuteAngle);
            return Math.Round(angle, 4)%180;
        }

        public static bool IsDevidedTwoHalf(double angle)
        {
            if (angle % 2.5 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int Counter()
        {
            int count = 0;
            count += Hours * 60;
            count += Hours * 6;
            count += Minutes / 10;
            count += Minutes;
            return count;
        }

        public static DialClock operator +(DialClock dc, DialClock other)
        {
            int totalMinutes = dc.hours * 60 + dc.minutes + other.hours * 60 + other.minutes;
            int newHours = totalMinutes / 60;
            int newMinutes = totalMinutes % 60;
            return new DialClock(newHours, newMinutes);
        }

        public static DialClock operator -(DialClock dc, DialClock other)
        {
            int totalMinutes = dc.hours * 60 + dc.minutes - other.hours * 60 - other.minutes;
            int newHours = totalMinutes / 60;
            int newMinutes = totalMinutes % 60;
            return new DialClock(newHours, newMinutes);
        }

        public virtual void Show()
        {
            Console.WriteLine($"Часы: {hours}, Минуты: {minutes}");
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (obj is DialClock clock)
            {
                return this.Hours == clock.Hours && this.Minutes == clock.Minutes;
            }
            else
            {
                return false;
            }
        }
    }
}
