namespace Lab8;

internal class Exercise1
{
    public static void Run()
    {
        // 1) Створення базового каталогу
        var basePath = @"D:\OOP_lab08";
        Directory.CreateDirectory(basePath);

        // 2) Створення підкаталогів 
        Directory.CreateDirectory(Path.Combine(basePath, "Group_Code"));
        Directory.CreateDirectory(Path.Combine(basePath, "Surname"));
        Directory.CreateDirectory(Path.Combine(basePath, "Sources"));
        Directory.CreateDirectory(Path.Combine(basePath, "Reports"));
        Directory.CreateDirectory(Path.Combine(basePath, "Texts"));

        // 3) Копіювання каталогів
        string[] directoriesToCopy = { "Texts", "Sources", "Reports" };
        foreach (var dir in directoriesToCopy)
        {
            Directory.CreateDirectory(Path.Combine(basePath, "Surname", dir));
            CopyDirectory(Path.Combine(basePath, dir), Path.Combine(basePath, "Surname", dir));
        }

        // 4) Переміщення каталогу Прізвища до Групи
        var sourceDir = Path.Combine(basePath, "Surname");
        var destinationDir = Path.Combine(basePath, "Group_Code", "Surname");
        if (Directory.Exists(sourceDir)) Directory.Move(sourceDir, destinationDir);

        // 5) Створення текстового файлу dirinfo.txt у каталозі Texts
        var dirInfoPath = Path.Combine(basePath, "Texts", "dirinfo.txt");
        var dirInfo = new DirectoryInfo(Path.Combine(basePath, "Texts"));
        using (var writer = new StreamWriter(dirInfoPath))
        {
            writer.WriteLine($"Назва: {dirInfo.FullName}");
            writer.WriteLine($"Створено: {dirInfo.CreationTime}");
            writer.WriteLine($"Змінено: {dirInfo.LastAccessTime}");
            writer.WriteLine($"Відкрито: {dirInfo.LastWriteTime}");
            writer.WriteLine($"Атрибути: {dirInfo.Attributes}");
            writer.WriteLine("Файли:");
            foreach (var file in dirInfo.GetFiles()) writer.WriteLine($"- {file.Name}");
            writer.WriteLine("Підкаталоги:");
            foreach (var dir in dirInfo.GetDirectories()) writer.WriteLine($"- {dir.Name}");
        }
    }

    private static void CopyDirectory(string sourceDir, string destinationDir)
    {
        Directory.CreateDirectory(destinationDir);

        foreach (var file in Directory.GetFiles(sourceDir))
        {
            var destFile = Path.Combine(destinationDir, Path.GetFileName(file));
            File.Copy(file, destFile, true);
        }

        foreach (var dir in Directory.GetDirectories(sourceDir))
        {
            var destDir = Path.Combine(destinationDir, Path.GetFileName(dir));
            CopyDirectory(dir, destDir);
        }
    }
}