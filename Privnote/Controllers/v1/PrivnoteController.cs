using Microsoft.AspNetCore.Mvc;
using Privnote.Contracts.v1;
using Privnote.DomainModel.Services.CryptService;

namespace Privnote.Controllers.v1;

public class PrivnoteController : ApiController
{
    [HttpGet(ApiRoutes.Notes.Create)]
    public string Create()
    {
        var stringCrypt = new StringCryptService();
        var encryptString = stringCrypt.Encrypt("Hello message test", "123321");
        
        return stringCrypt.Decrypt(encryptString, "asdasd");
    }
}