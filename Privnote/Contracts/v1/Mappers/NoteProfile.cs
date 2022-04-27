using AutoMapper;
using Privnote.Contracts.v1.Responses;
using Privnote.DomainModel.Models;

namespace Privnote.Contracts.v1.Mappers;

public class NoteProfile : Profile
{
    public NoteProfile()
    {
        CreateMap<Note, CreateNoteResponse>();
        CreateMap<Note, GetNoteResponse>();
    }
}