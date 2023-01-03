using System.Runtime.Serialization;

namespace GoStore.Domain.Exceptions;

[Serializable]
public sealed class InvalidStatusChangeException : Exception
{
    private InvalidStatusChangeException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    { }

    public InvalidStatusChangeException(string message = "The status cannot be changed. The order is invalid.")
        : base(message) { }

    public InvalidStatusChangeException(string message, Exception inner)
        : base(message, inner) { }
}