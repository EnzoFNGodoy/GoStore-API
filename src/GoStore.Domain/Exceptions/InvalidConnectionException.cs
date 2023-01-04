using System.Runtime.Serialization;

namespace GoStore.Domain.Exceptions;

[Serializable]
public sealed class InvalidConnectionException : Exception
{
    private InvalidConnectionException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    { }

    public InvalidConnectionException(string message = "The connection is refused or incorrect. Please retry with new credentials.")
        : base(message) { }

    public InvalidConnectionException(string message, Exception inner)
        : base(message, inner) { }
}