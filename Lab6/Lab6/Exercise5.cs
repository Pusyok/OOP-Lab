using System.Collections;

namespace Lab6;

internal class CollectionType
{
    public CollectionType(string name, string[] items)
    {
        Name = name;
        Items = new ArrayList();

        foreach (var item in items) Items.Add(item);
    }

    public string Name { get; set; }
    public ArrayList Items { get; set; }

    public ArrayList FindStringsContaining(string value)
    {
        var result = new ArrayList();
        foreach (string item in Items)
            if (item.Contains(value))
                result.Add(item);

        return result;
    }

    public int CountStringsWithLength(int length)
    {
        var count = 0;
        foreach (string item in Items)
            if (item.Length == length)
                count++;

        return count;
    }

    public void SortAscending()
    {
        Items.Sort();
    }

    public void SortDescending()
    {
        Items.Sort();
        Items.Reverse();
    }
    
    public override string ToString()
    {
        string result = $"Назва колекції: {Name}\nКількість елементів: {Items.Count}\nЕлементи:";
        foreach (string item in Items)
        {
            result += $"\n- {item}";
        }
        return result;
    }
}

internal class Exercise5
{
    public static void Run()
    {
        Console.WriteLine("\n=== Завдання 5 ===");
        
        var collections = new[]
        {
            new CollectionType("Перша колекція", ["яблуко", "груша", "слива", "персик"]),
            new CollectionType("Друга колекція", ["троянда", "тюльпан", "нарцис"]),
            new CollectionType("Третя колекція", ["собака", "кіт", "хом'як", "папуга", "риба"]),
            new CollectionType("Четверта колекція", ["стіл", "стілець", "шафа"]),
            new CollectionType("П'ята колекція", ["понеділок", "вівторок", "середа", "четвер", "п'ятниця"])
        };

        // Виведення інформації про колекції
        Console.WriteLine("\n=== Інформація про всі колекції ===");
        foreach (var collection in collections)
        {
            Console.WriteLine(collection);
            Console.WriteLine();
        }

        // Пошук рядків, що містять певне значення
        Console.WriteLine("\n=== Пошук рядків, що містять певне значення ===");
        string searchValue = "а";
        foreach (var collection in collections)
        {
            Console.WriteLine($"Колекція '{collection.Name}': рядки, що містять '{searchValue}':");
            var found = collection.FindStringsContaining(searchValue);
            if (found.Count > 0)
            {
                foreach (string item in found)
                {
                    Console.WriteLine($"- {item}");
                }
            }
            else
            {
                Console.WriteLine("- Нічого не знайдено");
            }
            Console.WriteLine();
        }

        // Підрахунок кількості рядків певної довжини
        Console.WriteLine("\n=== Підрахунок кількості рядків певної довжини ===");
        var length = 5;
        foreach (var collection in collections)
        {
            var count = collection.CountStringsWithLength(length);
            Console.WriteLine($"У колекції \"{collection.Name}\" кількість рядків довжини {length}: {count}");
        }

        // Сортування колекцій
        Console.WriteLine("\n=== Сортування колекцій ===");
        Console.WriteLine("Колекція 'Перша колекція' після сортування у зростаючому порядку:");
        collections[0].SortAscending();
        foreach (string item in collections[0].Items) Console.WriteLine($"- {item}");

        Console.WriteLine("\nКолекція 'Третя колекція' після сортування у спадному порядку:");
        collections[2].SortDescending();
        foreach (string item in collections[2].Items) Console.WriteLine($"- {item}");

        // Знайти кількість колекцій, сума яких більша за вказане значення
        Console.WriteLine("\n=== Кількість колекцій, сума яких більша за вказане значення ===");
        var threshold = 10;
        var collectionCount = CountCollectionsWithSumGreaterThan(collections, threshold);
        Console.WriteLine($"Кількість колекцій, сума яких більша за {threshold}: {collectionCount}");

        // Знайти максимальну та мінімальну колекцію
        Console.WriteLine("\n=== Максимальна та мінімальна колекція ===");
        var maxCollection = FindMaxCollection(collections);
        var minCollection = FindMinCollection(collections);

        Console.WriteLine($"Максимальна колекція: {maxCollection.Name} (кількість елементів: {maxCollection.Items.Count})");
        Console.WriteLine($"Мінімальна колекція: {minCollection.Name} (кількість елементів: {minCollection.Items.Count})");
    }
    
    private static CollectionType FindMaxCollection(CollectionType[] collections)
    {
        var maxCollection = collections[0];
        foreach (var collection in collections)
            if (collection.Items.Count > maxCollection.Items.Count)
                maxCollection = collection;

        return maxCollection;
    }

    private static CollectionType FindMinCollection(CollectionType[] collections)
    {
        var minCollection = collections[0];
        foreach (var collection in collections)
            if (collection.Items.Count < minCollection.Items.Count)
                minCollection = collection;

        return minCollection;
    }

    private static int CountCollectionsWithSumGreaterThan(CollectionType[] collections, int threshold)
    {
        var count = 0;
        foreach (var collection in collections)
        {
            var sum = 0;
            foreach (string item in collection.Items) sum += item.Length;

            if (sum > threshold) count++;
        }

        return count;
    }
}