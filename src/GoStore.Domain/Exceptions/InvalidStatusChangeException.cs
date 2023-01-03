namespace GoStore.Domain.Exceptions;

public sealed class InvalidStatusChangeException : Exception
{
    public InvalidStatusChangeException(string message = "The status cannot be changed. The order is invalid.")
        : base(message) { }

    public InvalidStatusChangeException(string message, Exception inner)
        : base(message, inner) { }
}