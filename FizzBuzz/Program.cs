using FizzBuzz.Exceptions;

namespace FizzBuzz;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // You can use string input for testing
            //var input = "Mary had a little lamb\nLittle lamb, little lamb\nMary had a little lamb\nIt's fleece was white\nMary had";
            
            // or you can use file input for testing
            var input = FileReader.ReadFile("input.txt");
            
            var result = FizzBuzzDetector.GetOverlappings(input);
            Console.WriteLine("output string:\n");
            Console.WriteLine(result.Output + "\n");
            Console.WriteLine("count: " + result.Count);
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine("File not found:\n");
            Console.WriteLine(e.Message);
        }
        catch (IOException e)
        {
            Console.WriteLine("An I/O error occurred:\n");
            Console.WriteLine(e.Message);
        }
        catch (InputException e)
        {
            Console.WriteLine("You have an input error:\n");
            Console.WriteLine(e.Message);
        }
        catch (OutputException e)
        {
            Console.WriteLine("You have an output error:\n");
            Console.WriteLine(e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine("An error occurred:\n");
            Console.WriteLine(e.Message);
        }
        finally
        {
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}