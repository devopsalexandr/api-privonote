using Microsoft.AspNetCore.Mvc;
using Privnote.DomainModel.Services.CryptService;

namespace Privnote.Controllers.v1;

public class PrivnoteController : ApiController
{
    [HttpGet("/test")]
    public string Test()
    {
        var stringCrypt = new StringCryptService();
        var encryptString = stringCrypt.Encrypt("Hello message test", "123321");
        
        return stringCrypt.Decrypt(encryptString, "asdasd");
    }
}