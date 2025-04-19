namespace Lab6;

internal class CollectionType<T>
{
    private readonly List<T> _items;

    // Конструктор
    public CollectionType()
    {
        _items = new List<T>();
    }

    // Властивості
    public int Count => _items.Count;
    public bool IsEmpty => _items.Count == 0;

    // Індексатор
    public T this[int index]
    {
        get => _items[index];
        set => _items[index] = value;
    }

    // Методи
    public void Add(T item)
    {
        _items.Add(item);
    }

    public void Remove(T item)
    {
        _items.Remove(item);
    }

    public void Clear()
    {
        _items.Clear();
    }
}