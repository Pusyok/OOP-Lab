namespace Lab5;

internal interface IPrintable
{
    void Print();
}

internal class Report : IPrintable
{
    public void Print()
    {
        Console.WriteLine("Друк звіту");
    }
}