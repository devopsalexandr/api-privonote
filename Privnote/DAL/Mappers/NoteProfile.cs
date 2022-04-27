using AutoMapper;
using Privnote.DAL.Entities;

namespace Privnote.DAL.Mappers;

public class NoteProfile : Profile
{
    public NoteProfile()
    {
        CreateMap<Note, DomainModel.Models.Note>();
    }
}