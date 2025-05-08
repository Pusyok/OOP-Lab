using System.Text;

namespace Lab107;

public class PremiyaException(string message) : Exception(message);

public class OkladException(string message) : Exception(message);

internal class UniversityName
{
    public UniversityName(string name)
    {
        Name = name;
    }

    public string Name { get; set; }
}

internal class Faculty
{
    public Faculty(string name, int numberOfTeachers)
    {
        Name = name;
        NumberOfTeachers = numberOfTeachers;
    }

    public string Name { get; set; }
    public int NumberOfTeachers { get; set; }
}

internal abstract class Teacher
{
    protected Teacher(string name, string position, float salary)
    {
        if (salary < 0) throw new OkladException("Зарплата не може бути від'ємною");

        Name = name;
        Position = position;
        Salary = salary;
    }

    public string Name { get; set; }
    public string Position { get; set; }
    public float Salary { get; set; }

    public abstract float CalculateSalary();
}

internal class StaffTeacher : Teacher
{
    public StaffTeacher(string name, string position, float salary, float bonus) : base(name, position, salary)
    {
        Bonus = bonus;
    }

    public float Bonus { get; set; }

    public override float CalculateSalary()
    {
        try
        {
            if (Bonus < 0) throw new PremiyaException("Премія не може бути від'ємною");
            return Salary + Bonus;
        }
        catch (PremiyaException ex)
        {
            Console.WriteLine($"Помилка розрахунку зарплати: {ex.Message}");
            return -1;
        }
    }
}

internal class PartTimeTeacher : Teacher
{
    public PartTimeTeacher(string name, string position, float salary) : base(name, position, salary)
    {
    }

    public override float CalculateSalary()
    {
        try
        {
            if (Salary < 0) throw new OkladException("Зарплата не може бути від'ємною");
            return Salary;
        }
        catch (OkladException ex)
        {
            Console.WriteLine($"Помилка розрахунку зарплати: {ex.Message}");
            return -1;
        }
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        try
        {
            var badTeacher = new StaffTeacher("Іван Іваненко", "Лектор", -20000, 2000);
        }
        catch (OkladException ex)
        {
            Console.WriteLine(ex.Message);
        }

        // Test PremiyaException in CalculateSalary
        var staffGood = new StaffTeacher("Петро Петренко", "Старший викладач", 30000, 4500);
        Console.WriteLine($"\nЗарплата штатного (коректна): {staffGood.CalculateSalary()} грн");

        var staffBad = new StaffTeacher("Олена Олененко", "Доцент", 40000, -8000);
        Console.WriteLine($"\nЗарплата штатного (з помилкою): {staffBad.CalculateSalary()} грн");

        // Test PartTimeLecturer
        var partTime = new PartTimeTeacher("Микола Миколенко", "Сумісник", 15000);
        Console.WriteLine($"\nЗарплата сумісника: {partTime.CalculateSalary()} грн");
    }
}