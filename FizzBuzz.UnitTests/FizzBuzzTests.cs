using FizzBuzz.Exceptions;

namespace FizzBuzz.UnitTests;

public class FizzBuzzTests
{
    [Fact]
    public void GetOverlappings_InputExceedsMaxLength_ShouldThrowInputException()
    {
        // Arrange
        // > 100 characters
        var input = "1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30 31 32 33 34 35 36 37 38 39 40 41 42 43 44 45";
        
        // Act
        var exception = Record.Exception(() => FizzBuzzDetector.GetOverlappings(input));
        
        // Assert
        Assert.NotNull(exception);
        Assert.IsType<InputException>(exception);
    }
    
    [Fact]
    public void GetOverlappings_InputBelowMinLength_ShouldThrowInputException()
    {
        // Arrange
        // < 7 characters
        var input = "1 2 3";
        
        // Act
        var exception = Record.Exception(() => FizzBuzzDetector.GetOverlappings(input));
        
        // Assert
        Assert.NotNull(exception);
        Assert.IsType<InputException>(exception);
    }
    
    [Fact]
    public void GetOverlappings_InputIsNull_ShouldThrowInputException()
    {
        // Arrange
        string input = null;
        
        // Act
        var exception = Record.Exception(() => FizzBuzzDetector.GetOverlappings(input));
        
        // Assert
        Assert.NotNull(exception);
        Assert.IsType<InputException>(exception);
    }
    
    [Fact]
    public void GetOverlappings_InputIsEmpty_ShouldThrowInputException()
    {
        // Arrange
        string input = string.Empty;
        
        // Act
        var exception = Record.Exception(() => FizzBuzzDetector.GetOverlappings(input));
        
        // Assert
        Assert.NotNull(exception);
        Assert.IsType<InputException>(exception);
    }
    
    [Fact]
    public void GetOverlappings_InputContainsOnlySpaces_ShouldThrowInputException()
    {
        // Arrange
        string input = "              ";
        
        // Act
        var exception = Record.Exception(() => FizzBuzzDetector.GetOverlappings(input));
        
        // Assert
        Assert.NotNull(exception);
        Assert.IsType<InputException>(exception);
    }
    
    [Fact]
    public void GetOverlappings_InputContainsOnlyEnters_ShouldThrowInputException()
    {
        // Arrange
        string input = "\n\n\n\n\n\n\n\n\n\n\n";
        
        // Act
        var exception = Record.Exception(() => FizzBuzzDetector.GetOverlappings(input));
        
        // Assert
        Assert.NotNull(exception);
        Assert.IsType<InputException>(exception);
    }
    
    [Fact]
    public void GetOverlappings_InputContains6LettersAndEnter_ShouldThrowInputException()
    {
        // Arrange
        string input = "123456\n";
        
        // Act
        var exception = Record.Exception(() => FizzBuzzDetector.GetOverlappings(input));
        
        // Assert
        Assert.NotNull(exception);
        Assert.IsType<InputException>(exception);
    }
    
    [Fact]
    public void GetOverlappings_InputContains100LettersAndEnters_ShouldReturnOutput()
    {
        // Arrange
        string input = "Mary had a little lamb\nLittle lamb, little lamb\nMary had a little lamb\nIt's fleece was white\nMary had";
        
        // Act
        var output = FizzBuzzDetector.GetOverlappings(input);
        
        // Assert
        Assert.NotNull(output);
        Assert.Equal("Mary had Fizz little Buzz\nFizz lamb, little Fizz\nBuzz had Fizz little lamb\nFizzBuzz fleece was Fizz\nMary Buzz", output.Output);
        Assert.Equal(9, output.Count);
    }
    
    [Fact]
    public void GetOverlappings_InputContains7LettersAndEnter_ShouldReturnOutput()
    {
        // Arrange
        string input = "1 2 3 4 5 6 7 8 9 10 11 12 13 14 15";
        
        // Act
        var output = FizzBuzzDetector.GetOverlappings(input);
        
        // Assert
        Assert.NotNull(output);
        Assert.Equal("1 2 Fizz 4 Buzz Fizz 7 8 Fizz Buzz 11 Fizz 13 14 FizzBuzz", output.Output);
        Assert.Equal(7, output.Count);
    }
}