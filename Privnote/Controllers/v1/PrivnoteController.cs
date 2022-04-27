using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Privnote.Contracts.v1;
using Privnote.Contracts.v1.Requests;
using Privnote.Contracts.v1.Responses;
using Privnote.DomainModel.Managers.NotesManager;

namespace Privnote.Controllers.v1;

public class PrivnoteController : ApiController
{
    private readonly INoteManager _noteManager;
    private readonly IMapper _mapper;

    public PrivnoteController(INoteManager noteManager, IMapper mapper)
    {
        _noteManager = noteManager ?? throw new ArgumentNullException(nameof(noteManager));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    
    [HttpPost(ApiRoutes.Notes.Show)]
    public async Task<IActionResult> Get([FromRoute] Guid id, [FromBody] GetNoteRequest request)
    { 
        var note = await _noteManager.GetNoteAsync(id, request.Password);

        if (note is null)
            return NotFound();

        return Ok(_mapper.Map<GetNoteResponse>(note));
    }

    [HttpPost(ApiRoutes.Notes.Create)]
    public async Task<IActionResult> Create([FromBody] CreateNoteRequest request)
    { 
        var newNote = await _noteManager.CreateNoteAsync(request.Text, request.Password);
        
        return Ok(_mapper.Map<CreateNoteResponse>(newNote));
    }
}