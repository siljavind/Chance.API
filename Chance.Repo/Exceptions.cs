public class NotFoundException : Exception
{
    public NotFoundException() : base() { }
    public NotFoundException(string message) : base(message) { }
    public NotFoundException(string message, Exception inner) : base(message, inner) { }
}

public class ConflictException : Exception
{
    public ConflictException() : base() { }
    public ConflictException(string message) : base(message) { }
    public ConflictException(string message, Exception inner) : base(message, inner) { }
}

public class BadRequestException : Exception
{
    public BadRequestException() : base() { }
    public BadRequestException(string message) : base(message) { }
    public BadRequestException(string message, Exception inner) : base(message, inner) { }
}