namespace Lab6;

internal class Exercise4
{
    public static void Run()
    {
        Console.WriteLine("\n=== Завдання 4 ===");
        
        // Створюємо список тварин для LINQ-запитів
        var animalList = CreateAnimalList();
        
        var query1 = animalList.GetAnimals()
            .Where(a => a.Habitat.Contains("Африка") && a.Population > 50000)
            .OrderBy(a => a.Group)
            .ThenBy(a => a.Name)
            .Select(a => a.Name);

        Console.WriteLine("\nАфриканські тварини з чисельністю > 50000:");
        foreach (var name in query1)
            Console.WriteLine(name);

        var query2 = animalList.GetAnimals()
            .GroupBy(a => a.Group)
            .Select(g => new
            {
                Group = g.Key,
                AveragePopulation = g.Average(a => a.Population)
            })
            .OrderByDescending(g => g.AveragePopulation);

        Console.WriteLine("\nСередня чисельність по групах:");
        foreach (var group in query2)
            Console.WriteLine($"Група {group.Group}: {group.AveragePopulation}");

        var query3 = animalList.GetAnimals()
            .Where(a => a.Population < 10000 && !a.Habitat.Contains("Африка"))
            .OrderBy(a => a.Population)
            .FirstOrDefault();

        Console.WriteLine("\nРідкісна неафриканська тварина з чисельністю < 10000:");
        query3?.WriteInfo();

        var query4 = animalList.GetAnimals()
            .Where(a => a.Group == "B")
            .Any(a => a.Population > 500000);

        Console.WriteLine($"\nЧи є у групі 'B' тварини з чисельністю > 500000? {query4}");

        var query5 = animalList.GetAnimals()
            .OrderByDescending(a => a.Population)
            .Select(a => new
            {
                a.Name,
                a.Habitat,
                Status = a.Population < 30000 ? "Рідкісна" : "Звичайна"
            })
            .Where(a => a.Habitat.Contains("Африка") || a.Habitat.Contains("Аравія"));

        Console.WriteLine("\nАфриканські/аравійські тварини зі статусом:");
        foreach (var item in query5)
            Console.WriteLine($"{item.Name}, {item.Habitat}, Статус: {item.Status}");
    }
    
    private static AnimalList<Animal> CreateAnimalList()
    {
        var animalList = new AnimalList<Animal>();
        animalList.Add(new Animal("Джейран", "A", "Азія", 30000));
        animalList.Add(new Animal("Гну", "B", "Африка", 560000));
        animalList.Add(new Animal("Бейза", "H", "Африка", 2500));
        animalList.Add(new Animal("Канна", "C", "Африка", 120000));
        animalList.Add(new Animal("Імпала", "B", "Африка", 200000));
        animalList.Add(new Animal("Сайгак", "A", "Євразія", 15000));
        animalList.Add(new Animal("Ньяла", "C", "Африка", 35000));
        animalList.Add(new Animal("Орикс", "H", "Аравія", 7000));
        animalList.Add(new Animal("Томсон", "B", "Африка", 550000));
        animalList.Add(new Animal("Спрінгбок", "C", "Південна Африка", 100000));
        return animalList;
    }
}