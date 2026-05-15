using System.Net.Http;

namespace Dedalus.Exceptions;

public class DedalusForbiddenException : Dedalus4xxException
{
    public DedalusForbiddenException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
