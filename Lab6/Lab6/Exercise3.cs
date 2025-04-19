namespace Lab6;

internal class AnimalList<T> where T : Animal
{
    private readonly List<T> animals = new();

    public void Add(T animal)
    {
        animals.Add(animal);
    }

    public void Remove(T animal)
    {
        animals.Remove(animal);
    }

    public void SortAnimals()
    {
        animals.Sort();
    }

    public void PrintAnimals()
    {
        foreach (var animal in animals) animal.WriteInfo();
    }

    public List<T> GetAnimals()
    {
        return animals;
    }
}

internal class Animal : IComparable<Animal>
{
    private string _group;
    private string _habitat;

    private string _name;
    private int _population;

    // Конструктор по замовчуванню
    public Animal()
    {
        _name = "Невідомо";
        _group = "Невідомо";
        _habitat = "Невідомо";
        _population = -1;
    }

    // Конструктор ініціалізації
    public Animal(string name, string group, string habitat, int population)
    {
        Name = name;
        Group = group;
        Habitat = habitat;
        Population = population;
    }

    // Конструктор копіювання
    public Animal(Animal previous)
    {
        _name = previous._name;
        _group = previous._group;
        _habitat = previous._habitat;
        _population = previous._population;
    }

    // Аксесори та мутатори
    public string Name
    {
        get => _name;
        set => _name = !string.IsNullOrWhiteSpace(value) ? value : "Невідомо";
    }

    public string Group
    {
        get => _group;
        set => _group = !string.IsNullOrWhiteSpace(value) ? value : "Невідомо";
    }

    public string Habitat
    {
        get => _habitat;
        set => _habitat = !string.IsNullOrWhiteSpace(value) ? value : "Невідомо";
    }

    public int Population
    {
        get => _population;
        set => _population = value >= 0 ? value : -1;
    }

    public int CompareTo(Animal? other)
    {
        if (other == null) return 1;
        // Сортуємо за популяцією
        return Population.CompareTo(other.Population);
    }

    public void WriteInfo()
    {
        Console.WriteLine($"Назва: {Name}, Група: {Group}, Житло: {Habitat}, Чисельність: {Population}");
    }

    // Деструктор
    ~Animal()
    {
        Console.WriteLine($"Тварину {Name} видалено");
    }
}

internal class Exercise3
{
    public static void Run()
    {
        Console.WriteLine("\n=== Завдання 3 ===");
        
        var antelope1 = new Animal("Джейран", "A", "Азія", 30000);
        var antelope2 = new Animal("Гну", "B", "Африка", 560000);
        var antelope3 = new Animal("Бейза", "H", "Африка", 2500);
        var antelope4 = new Animal("Канна", "C", "Африка", 120000);
        var antelope5 = new Animal("Імпала", "B", "Африка", 200000);
        var antelope6 = new Animal("Сайгак", "A", "Євразія", 15000);
        var antelope7 = new Animal("Ньяла", "C", "Африка", 35000);
        var antelope8 = new Animal("Орикс", "H", "Аравія", 7000);
        var antelope9 = new Animal("Томсон", "B", "Африка", 550000);
        var antelope10 = new Animal("Спрінгбок", "C", "Південна Африка", 100000);

        var animalList = new AnimalList<Animal>();
        animalList.Add(antelope1);
        animalList.Add(antelope2);
        animalList.Add(antelope3);
        animalList.Add(antelope4);
        animalList.Add(antelope5);
        animalList.Add(antelope6);
        animalList.Add(antelope7);
        animalList.Add(antelope8);
        animalList.Add(antelope9);
        animalList.Add(antelope10);

        Console.WriteLine("Список тварин до сортування:");
        animalList.PrintAnimals();

        Console.WriteLine("\nСписок тварин після сортування:");
        animalList.SortAnimals();
        animalList.PrintAnimals();

        var filteredAnimals = animalList.GetAnimals()
            .Where(a => a.Population > 10000)
            .OrderBy(a => a.Name);

        Console.WriteLine("\nТварини з чисельністю більше 10000:");
        foreach (var animal in filteredAnimals) Console.WriteLine($"Назва: {animal.Name}");
    }
}