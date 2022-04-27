using System.Runtime.Serialization;

namespace Privnote.DomainModel.Exceptions;

public class EntityNotFoundException : ApplicationException
{
    public EntityNotFoundException() { }

    public EntityNotFoundException(string message) : base(message) { }

    public EntityNotFoundException(string message, Exception inner) : base(message, inner) { }

    protected EntityNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}