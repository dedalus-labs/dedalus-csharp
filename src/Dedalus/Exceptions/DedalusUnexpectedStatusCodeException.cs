using System.Net.Http;

namespace Dedalus.Exceptions;

public class DedalusUnexpectedStatusCodeException : DedalusApiException
{
    public DedalusUnexpectedStatusCodeException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
