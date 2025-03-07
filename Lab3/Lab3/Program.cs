using System.Text;

namespace Lab3;

internal class Program
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        Exercise1();
        Exercise2();
        Exercise3();
    }

    private static void Exercise1()
    {
        Console.WriteLine("\n========= Задача 1 =========");

        // Створення автомобіля та мотоцикла
        var car1 = new Car("M5", "BMW");
        var bike1 = new Bike("CBR1000RR", "Honda");

        // Викликання перевизначеної функції
        car1.Describe();
        bike1.Describe();
    }

    private static void Exercise2()
    {
        Console.WriteLine("\n========= Задача 2 =========");

        // Створення співробітників
        var regular = new Employee("Андрій Коваленко", "Розробник", 30000);
        var manager = new Manager("Іван Сидоренко", 35000, 15000);

        // Пряме використання об'єктів
        Console.WriteLine($"Інформація: {regular.EmployeeInfo}");
        Console.WriteLine($"Зарплата: {regular.Salary:C}");

        // Виведе повну інформацію про менеджера, включаючи: Базову ставку, Бонус, Загальну зарплату
        Console.WriteLine($"Інформація: {manager.EmployeeInfo}");
        Console.WriteLine($"Зарплата: {manager.Salary:C}");

        // Використання поліморфізму
        Console.WriteLine("==== Використання Поліморфізму ====");
        Employee[] employees = { regular, manager };

        foreach (var employee in employees)
        {
            // Виведе лише ту інформацію яка виводиться в базовому класі `Employee`
            // Тобто тільки Позицію та Зарплату
            Console.WriteLine($"Інформація: {employee.EmployeeInfo}");
            // Натомість, зарплатня виведеться правильно, викликаючи перевизначений метод в класі `Manager`
            Console.WriteLine($"Зарплата: {employee.Salary:C}");
        }
    }

    private static void Exercise3()
    {
        Console.WriteLine("\n========= Задача 3 =========");

        // Створення пар ключ-значення
        var dict = new KeyValue<string, int>();

        // Додання об'єктів до списку
        dict.Add("Яблука", 5);
        dict.Add("Банани", 2);
        dict.Add("Кокоси", 1);

        // Повторне додавання вже існуючого ключа
        dict.Add("Яблука", 1);

        // Зчитування значення одного ключа
        Console.WriteLine($"Кількість яблук: {dict.GetValue("Яблука")}");
        dict.Set("Яблука", 10);
        Console.WriteLine($"Змінена кількість яблук: {dict.GetValue("Яблука")}");

        // Виведення всіх пар
        dict.PrintAll();
    }
}