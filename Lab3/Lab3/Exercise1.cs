namespace Lab3;

// Задача 1. Ієрархія транспорту.
// Базовий клас, що містить загальні властивості для всіх транспортних засобів
internal class Vehicle(string name, string manufacturer)
{
    public string Name { get; } = name;
    public string Manufacturer { get; } = manufacturer;

    // Віртуальний метод для опису транспортного засобу, який може бути перевизначений у похідних класах
    public virtual void Describe()
    {
        Console.WriteLine($"Опис транспортного засобу. Ім'я: {Name}, Виробник: {Manufacturer}");
    }
}

// Похідний клас, що представляє автомобіль
internal class Car(string name, string manufacturer) : Vehicle(name, manufacturer)
{
    // Перевизначений метод для опису автомобіля
    public override void Describe()
    {
        Console.WriteLine($"Опис автомобіля: Ім'я: {Name}, Виробник: {Manufacturer}");
    }
}

// Похідний клас, що представляє мотоцикл
internal class Bike(string name, string manufacturer) : Vehicle(name, manufacturer)
{
    // Перевизначений метод для опису мотоцикла 
    public override void Describe()
    {
        Console.WriteLine($"Опис мотоцикла: Ім'я: {Name}, Виробник: {Manufacturer}");
    }
}