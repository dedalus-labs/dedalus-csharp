using System;
using System.Net.Http;

namespace Dedalus.Exceptions;

public class DedalusIOException : DedalusException
{
    public new HttpRequestException InnerException
    {
        get
        {
            if (base.InnerException == null)
            {
                throw new ArgumentNullException();
            }
            return (HttpRequestException)base.InnerException;
        }
    }

    public DedalusIOException(string message, HttpRequestException? innerException = null)
        : base(message, innerException) { }
}
