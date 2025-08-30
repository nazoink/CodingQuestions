public class Program
{
    public static void Main(string[] args)
    {
        Calc calc = new Calc();
        Console.WriteLine(calc.Add(5, 3));
        Console.WriteLine(calc.Subtract(5, 3));
        Console.WriteLine(calc.Multiply(5, 3));
        Console.WriteLine(calc.Divide(5, 1));
    }
}

public class Calc
{
    public int Add(int a, int b)
    {
        return a + b;
    }
    public int Subtract(int a, int b)
    {
        return a - b;
    }
    public int Multiply(int a, int b)
    {
        return a * b;
    }
    public int Divide(int a, int b)
    {
        if (b == 0)
            throw new System.DivideByZeroException("Denominator cannot be zero.");
        return a / b;
    }
}