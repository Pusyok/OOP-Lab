namespace Lab8;

internal class Exercise2
{
    public static void Run()
    {
        var filePath = "f.txt"; // шлях до файлу
        using (var reader = new StreamReader(filePath))
        {
            var firstChar = reader.Read();
            var secondChar = reader.Read();

            if (firstChar == -1 || secondChar == -1)
            {
                Console.WriteLine("Файл містить менше двох символів.");
                return;
            }

            var ch1 = (char)firstChar;
            var ch2 = (char)secondChar;

            if (char.IsDigit(ch1) && char.IsDigit(ch2))
            {
                var number = int.Parse($"{ch1}{ch2}");
                Console.WriteLine($"Перші два символи — цифри: {ch1}, {ch2}");
                Console.WriteLine($"Число: {number}");
                Console.WriteLine(number % 2 == 0 ? "Число парне." : "Число непарне.");
            }
            else
            {
                Console.WriteLine("Перші два символи не є обидва цифрами.");
            }
        }
    }
}