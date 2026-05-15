using System;

namespace Dedalus.Exceptions;

public class DedalusSseException : DedalusException
{
    public DedalusSseException(string message, Exception? innerException = null)
        : base(message, innerException) { }
}
