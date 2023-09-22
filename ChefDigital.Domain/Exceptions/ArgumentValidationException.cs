using System;

public class ArgumentValidationException : Exception
{
    public ArgumentValidationException()
    {
    }

    public ArgumentValidationException(string message)
        : base(message)
    {
    }

    public ArgumentValidationException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
