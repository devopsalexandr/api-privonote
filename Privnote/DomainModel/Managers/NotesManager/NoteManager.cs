using System.Security.Cryptography;
using Privnote.DomainModel.Models;
using Privnote.DomainModel.Repositories;
using Privnote.DomainModel.Services.CryptService;

namespace Privnote.DomainModel.Managers.NotesManager;

public class NoteManager : INoteManager
{
    private readonly INoteRepository _noteRepository;

    public NoteManager(INoteRepository noteRepository)
    {
        _noteRepository = noteRepository ?? throw new ArgumentNullException();
    }

    public Task<Note> CreateNoteAsync(string text, string password)
    {
        var stringCrypt = new StringCryptService(password);
        var encryptedString = stringCrypt.Encrypt(text);

        return _noteRepository.CreateAsync(encryptedString);
    }
    
    public async Task<Note?> GetNoteAsync(Guid id, string password)
    {
        var note = await _noteRepository.GetAsync(id);
        
        if(note is null) return null;
        
        var stringCrypt = new StringCryptService(password);

        try
        {
            var decryptedString = stringCrypt.Decrypt(note.Text);
            note.Text = decryptedString;

            await _noteRepository.DeleteAsync(note.Id);

            return note;
        }
        catch (CryptographicException e)
        {
            if (note.ReadAttempts >= 2)
            {
                await _noteRepository.DeleteAsync(note.Id);
                return null;
            }

            await _noteRepository.AddAttempts(note.Id);
            return null;
        }

    }
}