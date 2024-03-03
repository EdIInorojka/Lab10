public class IdNumber
{
    public int number;

    public IdNumber()
    {
        number = 0;
    }

    public IdNumber(int number)
    {
        if (number < 0)
        {
            throw new ArgumentException("Number cannot be less than 0");
        }

        this.number = number;
    }

    public bool Equals(IdNumber other)
    {
        return this.number == other.number;
    }

    public override bool Equals(object obj)
    {
        if (obj is IdNumber other)
        {
            return Equals(other);
        }

        return false;
    }

    public override int GetHashCode()
    {
        return number.GetHashCode();
    }

    public override string ToString()
    {
        return number.ToString();
    }
}