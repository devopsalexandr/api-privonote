using Privnote.DomainModel.Models;

namespace Privnote.DomainModel.Repositories;

public interface INoteRepository
{
    public Task<Note?> GetAsync(Guid id);
    
    public Task<Note> CreateAsync(string text);
    
    public Task DeleteAsync(Guid id);

    public Task AddAttempts(Guid id);
}