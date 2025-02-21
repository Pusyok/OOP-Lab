namespace Lab1;

class Animal
{
    private string _name;
    private string _group;
    private string _habitat;
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
        this.Name = name;
        this.Group = group;
        this.Habitat = habitat;
        this.Population = population;
    }

    // Конструктор копіювання
    public Animal(Animal previous)
    {
        this._name = previous._name;
        this._group = previous._group;
        this._habitat = previous._habitat;
        this._population = previous._population;
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
    
    public string Habitat {
        get => _habitat;
        set => _habitat = !string.IsNullOrWhiteSpace(value) ? value : "Невідомо";
    }
    
    public int Population {
        get => _population;
        set => _population = value >= 0 ? value : -1;
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

class Program 
{
    public static void Main() 
    { 
        var antelope1 = new Animal("Джейран", "A", "Азія", 30000);
        var antelope2 = new Animal("Гну", "B", "Африка", 560000);
        var antelope3 = new Animal("Бейза", "H", "Африка", 2500);
        
        antelope1.WriteInfo();
        antelope2.WriteInfo();
        antelope3.WriteInfo();
    } 
} 

