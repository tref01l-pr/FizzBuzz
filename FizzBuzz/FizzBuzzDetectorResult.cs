using FizzBuzz.Exceptions;

namespace FizzBuzz;

// record to store the result of the FizzBuzzDetector
public record FizzBuzzDetectorResult
{
    public int Count { get; }
    public string Output { get; }

    private FizzBuzzDetectorResult(string output, int count)
    {
        Output = output;
        Count = count;
    }
    
    public static FizzBuzzDetectorResult Create(int count, string output)
    {
        if (string.IsNullOrWhiteSpace(output))
        {
            throw new OutputException("Output can not be null or has only spaces.");
        }
        
        if (count < 0)
        {
            throw new OutputException("Count can not be negative.");
        }
        
        return new FizzBuzzDetectorResult(output, count);
    }
}