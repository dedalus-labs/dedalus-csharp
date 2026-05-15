using System.Net.Http;

namespace Dedalus.Exceptions;

public class DedalusRateLimitException : Dedalus4xxException
{
    public DedalusRateLimitException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
