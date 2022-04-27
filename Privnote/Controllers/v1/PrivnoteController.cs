using Microsoft.AspNetCore.Mvc;
using Privnote.Contracts.v1;
using Privnote.Contracts.v1.Requests;
using Privnote.DomainModel.Managers.NotesManager;
using Privnote.DomainModel.Services.CryptService;

namespace Privnote.Controllers.v1;

public class PrivnoteController : ApiController
{
    private readonly INoteManager _noteManager;

    public PrivnoteController(INoteManager noteManager)
    {
        _noteManager = noteManager ?? throw new ArgumentNullException(nameof(noteManager));
    }
    
    [HttpPost(ApiRoutes.Notes.Show)]
    public async Task<IActionResult> Get([FromRoute] Guid id, [FromBody] GetNoteRequest request)
    { 
        var note = await _noteManager.GetNoteAsync(id, request.Password);

        if (note is null)
            return NotFound();
        
        return Ok(note);
    }

    [HttpPost(ApiRoutes.Notes.Create)]
    public async Task<IActionResult> Create([FromBody] CreateNoteRequest request)
    { 
        var newNote = await _noteManager.CreateNoteAsync(request.Text, request.Password);
        
        return Ok(newNote);
    }
}