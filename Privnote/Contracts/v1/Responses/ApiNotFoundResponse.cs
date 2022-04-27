using System.Net;

namespace Privnote.Contracts.v1.Responses;

public class ApiNotFoundResponse
{
    public int StatusCode { get; }
    public string Message { get; }
    
    
    public ApiNotFoundResponse(HttpStatusCode code, string message = null)
    {
        StatusCode = (int)code;
        Message = message;
    }
}