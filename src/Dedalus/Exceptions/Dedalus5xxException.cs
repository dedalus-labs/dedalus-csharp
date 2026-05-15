using System.Net.Http;

namespace Dedalus.Exceptions;

public class Dedalus5xxException : DedalusApiException
{
    public Dedalus5xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
