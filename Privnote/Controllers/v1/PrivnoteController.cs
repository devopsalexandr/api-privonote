using Microsoft.AspNetCore.Mvc;
using Privnote.Contracts.v1;
using Privnote.Contracts.v1.Requests;
using Privnote.DomainModel.Services.CryptService;

namespace Privnote.Controllers.v1;

public class PrivnoteController : ApiController
{
    [HttpGet(ApiRoutes.Notes.Create)]
    public IActionResult Create(CreateNoteRequest request)
    {
       

        return Ok();
    }
}