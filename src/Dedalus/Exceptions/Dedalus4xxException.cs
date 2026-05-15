using System.Net.Http;

namespace Dedalus.Exceptions;

public class Dedalus4xxException : DedalusApiException
{
    public Dedalus4xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
