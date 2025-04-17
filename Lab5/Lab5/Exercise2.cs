namespace Lab5; 

interface IA
{
    void MethodA();
}

interface IB : IA
{
    void MethodB();
}

class MyClass : IB
{
    public void MethodA()
    {
        Console.WriteLine("Method A");
    }

    public void MethodB()
    {
        Console.WriteLine("Method B");
    }
}