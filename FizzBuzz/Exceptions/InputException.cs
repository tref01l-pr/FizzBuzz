using System.ComponentModel.DataAnnotations;

namespace FizzBuzz.Exceptions;

public class InputException : ValidationException
{
    public InputException(string message) : base(message) { }
}