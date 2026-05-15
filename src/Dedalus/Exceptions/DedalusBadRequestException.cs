using System.Net.Http;

namespace Dedalus.Exceptions;

public class DedalusBadRequestException : Dedalus4xxException
{
    public DedalusBadRequestException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
