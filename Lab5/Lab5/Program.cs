namespace Lab5;

internal class Program
{
    private static void Main(string[] args)
    {
        // Завдання 1
        Console.WriteLine("Завдання 1: ");
        
        var report = new Report();
        report.Print();

        // Завдання 2
        Console.WriteLine("\nЗавдання 2: ");
        
        var myClass = new MyClass();
        myClass.MethodA();
        myClass.MethodB();
        
        // Завдання 3
        var students = new List<Student>
        {
            new Student { Name = "Taras", Grade = 85 },
            new Student { Name = "Andriy", Grade = 90 },
            new Student { Name = "Artem", Grade = 81 },
            new Student { Name = "Oleg", Grade = 95 },
            new Student { Name = "Ivan", Grade = 70 },
            new Student { Name = "Oleksandr", Grade = 75 },
        };
        
        students.Sort();
        
        Console.WriteLine("\nСтуденти відсортовані за оцінками:");
        foreach (var student in students)
        {
            Console.WriteLine($"{student.Name}: {student.Grade}");
        }
    }
}