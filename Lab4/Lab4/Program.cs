using System.Text;

namespace Lab4;

internal class Program
{
    private static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        Exercise1();
        Console.WriteLine("\n\n\n\n");
        Exercise2();
    }

    private static void Exercise1()
    {
        var min1 = new Minute(25);
        var time1 = new Time(18, min1);
        var day1 = new Day(time1);

        Console.WriteLine("===== Доба 1 =====");
        day1.WriteCurrentTime();
        Console.WriteLine($"Час доби: {day1.CalculateDayTime()}");
        Console.WriteLine($"ToString(): {day1}");

        var min2 = new Minute(38);
        var time2 = new Time(1, min2);
        var day2 = new Day(time2);

        Console.WriteLine("\n===== Доба 2 =====");
        day2.WriteCurrentTime();
        Console.WriteLine($"Час доби: {day2.CalculateDayTime()}");
        Console.WriteLine($"ToString(): {day2}");

        Console.WriteLine("\n===== Порівняння =====");
        Console.WriteLine("Порівнянни доби 1 та доби 2: " + (day1.Equals(day2) ? "Однакові" : "Різні"));
    }

    private static void Exercise2()
    {
        var matrixA = new TMatrix3(new float[,]
        {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
        });
        
        var matrixB = new TMatrix2(new float[,]
        {
            { 1, 2 },
            { 3, 4 }
        });

        Console.WriteLine("===== Матриця A =====");
        matrixA.PrintMatrix();

        Console.WriteLine("===== Матриця B =====");
        matrixB.PrintMatrix();

        Console.WriteLine("===== Обчислення виразу =====");
        var sumA = matrixA.Sum();
        var detA = Math.Abs(matrixA.Determinant());
        var detB = Math.Abs(matrixB.Determinant());

        var result = sumA + detA + detB;

        Console.WriteLine($"Сума елементів матриці B: {sumA}");
        Console.WriteLine($"Модуль детермінанта матриці A: {detA}");
        Console.WriteLine($"Модуль детермінанта матриці B: {detB}");
        Console.WriteLine($"Результат: {result}");
    }
}