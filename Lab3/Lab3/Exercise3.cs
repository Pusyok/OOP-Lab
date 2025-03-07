namespace Lab3;

// Задача 3. Узагальнене зберігання.
// Узагальнений клас для зберігання пар ключ-значення будь-якого типу
public class KeyValue<TKey, TValue>
{
    // Приватний словник для зберігання пар ключ-значення
    private readonly Dictionary<TKey, TValue> _dictionary;

    public KeyValue()
    {
        _dictionary = new Dictionary<TKey, TValue>();
    }

    // Перевіряє чи існує елемент з вказаним ключем
    public bool HasKey(TKey key)
    {
        return _dictionary.ContainsKey(key);
    }

    // Додає нову пару ключ-значення, якщо такого ключа ще немає
    public void Add(TKey key, TValue value)
    {
        if (!HasKey(key))
            _dictionary.Add(key, value);
        else
            Console.WriteLine("Ключ вже існує в списку");
    }

    // Оновлює значення для існуючого ключа
    public void Set(TKey key, TValue value)
    {
        if (!HasKey(key))
        {
            Console.WriteLine($"Ключа не існує {key}");
            return;
        }

        _dictionary[key] = value;
    }

    // Видаляє пару за ключем
    public void Remove(TKey key)
    {
        _dictionary.Remove(key);
    }

    // Повертає значення за ключем
    public TValue GetValue(TKey key)
    {
        return _dictionary[key];
    }

    // Виводить всі пари ключ-значення 
    public void PrintAll()
    {
        foreach (var keyValue in _dictionary) Console.WriteLine($"{keyValue.Key}: {keyValue.Value}");
    }
}