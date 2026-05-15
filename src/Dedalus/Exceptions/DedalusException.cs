using System;
using System.Net.Http;

namespace Dedalus.Exceptions;

public class DedalusException : Exception
{
    public DedalusException(string message, Exception? innerException = null)
        : base(message, innerException) { }

    protected DedalusException(HttpRequestException? innerException)
        : base(null, innerException) { }
}
