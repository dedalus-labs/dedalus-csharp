using System;

namespace Dedalus.Exceptions;

public class DedalusInvalidDataException : DedalusException
{
    public DedalusInvalidDataException(string message, Exception? innerException = null)
        : base(message, innerException) { }
}
