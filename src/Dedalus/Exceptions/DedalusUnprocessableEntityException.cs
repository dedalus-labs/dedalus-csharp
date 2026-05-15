using System.Net.Http;

namespace Dedalus.Exceptions;

public class DedalusUnprocessableEntityException : Dedalus4xxException
{
    public DedalusUnprocessableEntityException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
