using System.ComponentModel.DataAnnotations;

namespace FizzBuzz.Exceptions;

public class OutputException : ValidationException
{
    public OutputException(string message) : base(message) { }
}