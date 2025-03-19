namespace FizzBuzz;

//static class for reading the file
public static class FileReader
{
    public static string ReadFile(string path)
    {
        string projectDirectory = Directory.GetParent(AppContext.BaseDirectory).Parent.Parent.Parent.FullName;

        string filePath = Path.Combine(projectDirectory, "input.txt");

        string[] lines = File.ReadAllLines(filePath);
        return string.Join("\n", lines);
    }
}