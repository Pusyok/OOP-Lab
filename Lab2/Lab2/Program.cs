using Lab2;

namespace Lab2
{
    // Задача 1. Ініціалізатори властивостей
    class Book
    {
        public string Title { get; }
        public string Author { get; }

        public Book(string title, string author)
        {
            Title = title;
            Author = author;
        }
    }

    // Задача 2. Робота зі структурами
    struct Rectangle
    {
        public double Width { get; }
        public double Height { get; }

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public double Area()
        {
            return Width * Height;
        }
    }
}

// Задача 3. Глобальний простір імен
class GlobalExample
{
    public void ShowMessage(string text)
    {
        Console.WriteLine("GlobalExample: " + text);
    }
}

class Program
{
    static void Main(string[] args)
    {
        var book = new Book("1984", "Джордж Орвелл");
        Console.WriteLine($"Книга: {book.Title}, Автор: {book.Author}");
        
        var rectangle = new Rectangle(5, 6);
        Console.WriteLine($"Площа прямокутника з розмірами {rectangle.Width}x{rectangle.Height} = {rectangle.Area()}");
        
        var example = new GlobalExample();
        example.ShowMessage("Повідомлення");
    }
}