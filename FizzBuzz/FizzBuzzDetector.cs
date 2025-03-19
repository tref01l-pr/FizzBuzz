using System.Text;
using FizzBuzz.Exceptions;

namespace FizzBuzz;

public static class FizzBuzzDetector
{
    public static FizzBuzzDetectorResult GetOverlappings(string input)
    {
        ValidateInput(input);
        
        ProcessInput(input, out var replacementCount, out var output);

        return FizzBuzzDetectorResult.Create(replacementCount, output);
    }
    
    // Process the input and replace the words with Fizz, Buzz or FizzBuzz
    private static void ProcessInput(string input, out int replacementCount, out string output)
    {
        var outputBuilder = new StringBuilder();
        var currentWord = new StringBuilder();

        output = string.Empty;
        replacementCount = 0;
        
        var numberOfWord = 0;
        
        var isInWord = false;

        try
        {
            foreach (var letter in input)
            {
                if (IsAlphaNumeric(letter))
                {
                    if (!isInWord)
                    {
                        isInWord = true;
                        currentWord.Clear();
                    }

                    currentWord.Append(letter);
                    continue;
                }
                
                if (isInWord)
                {
                    isInWord = false;
                    numberOfWord++;

                    if (ProcessWord(numberOfWord, currentWord, outputBuilder)) 
                        replacementCount++;
                }

                outputBuilder.Append(letter);
            }
            
            if (!isInWord)
                return;
        
            // Case when the input ends with a word
            numberOfWord++;
            if (ProcessWord(numberOfWord, currentWord, outputBuilder)) 
                replacementCount++;
        }
        finally
        {
            // Set the output
            output = outputBuilder.ToString();
        }
    }
    
    // Process the word and replace it with Fizz, Buzz or FizzBuzz or keep it as it is
    private static bool ProcessWord(int wordCount, StringBuilder currentWord, StringBuilder result)
    {
        if (TryReplaceWord(wordCount % 3 == 0, wordCount % 5 == 0, result))
            return true;
        
        result.Append(currentWord);
        return false;
    }
    
    // Replace the word with Fizz, Buzz or FizzBuzz
    private static bool TryReplaceWord(bool isFizz, bool isBuzz, StringBuilder result)
    {
        if (isFizz && isBuzz)
        {
            result.Append("FizzBuzz");
            return true;
        }

        if (isFizz)
        {
            result.Append("Fizz");
            return true;
        }

        if (isBuzz)
        {
            result.Append("Buzz");
            return true;
        }

        return false;
    }
    

    // Validate the input
    private static void ValidateInput(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            throw new InputException("Your input can not be null or contains only spaces.");
        }
        
        // Remove spaces, new lines to check the length of the input
        var validCharCount = input.Count(letter => letter is not ('\n' or '\r'));

        if (validCharCount == 0)
        {
            throw new InputException("Your input cannot contain only spaces.");
        }

        if (validCharCount is <= 7 or >= 100)
        {
            throw new InputException("Your input must be between 7 and 100 characters.");
        }
    }

    // Check if the letter is an alphanumeric character
    private static bool IsAlphaNumeric(char letter)
    {
        switch (letter)
        {
            case >= '0' and <= '9':
            case >= 'A' and <= 'Z':
            case >= 'a' and <= 'z':
                return true;
            default:
                //Check if it is (') 
                return letter == 39;
        }
    }
}