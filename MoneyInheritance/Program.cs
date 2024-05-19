public class Money
{
    private int wholePart;
    private int fractionalPart;

    public int WholePart
    {
        get { return wholePart; }
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException("Whole part cannot be negative.");
            wholePart = value;
        }
    }

    public int FractionalPart
    {
        get { return fractionalPart; }
        set
        {
            if (value < 0 || value >= 100)
                throw new ArgumentOutOfRangeException("Fractional part must be between 0 and 99.");
            fractionalPart = value;
        }
    }

    public Money(int wholePart, int fractionalPart)
    {
        WholePart = wholePart;
        FractionalPart = fractionalPart;
    }

    public void Display()
    {
        Console.WriteLine($"{WholePart}.{FractionalPart:D2}");
    }

    public void SetValues(int wholePart, int fractionalPart)
    {
        WholePart = wholePart;
        FractionalPart = fractionalPart;
    }

    public void Subtract(Money amount)
    {
        int totalCents = (WholePart * 100 + FractionalPart) - (amount.WholePart * 100 + amount.FractionalPart);

        if (totalCents < 0)
            throw new InvalidOperationException("Resulting amount cannot be negative.");

        WholePart = totalCents / 100;
        FractionalPart = totalCents % 100;
    }
}

public class Product
{
    public string Name { get; set; }
    public Money Price { get; set; }

    public Product(string name, Money price)
    {
        Name = name;
        Price = price;
    }

    public void ReducePrice(Money amount)
    {
        Price.Subtract(amount);
    }

    public void Display()
    {
        Console.Write($"{Name}: ");
        Price.Display();
    }
}

public class Program
{
    public static void Main()
    {
        Money price = new Money(10, 50);
        Product product = new Product("Sample Product", price);

        product.Display();

        Money discount = new Money(2, 75);
        product.ReducePrice(discount);

        product.Display();
    }
}
