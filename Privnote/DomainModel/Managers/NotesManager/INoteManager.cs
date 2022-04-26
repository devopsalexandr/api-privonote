using Privnote.DomainModel.Models;

namespace Privnote.DomainModel.Managers.NotesManager;

public interface INoteManager
{
    public Task CreateNoteAsync(string text, string password);

    public Task<Note?> GetNoteAsync(Guid id, string password);
}