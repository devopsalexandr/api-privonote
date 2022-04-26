using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Privnote.DomainModel.Exceptions;
using Privnote.DomainModel.Models;
using Privnote.DomainModel.Repositories;

namespace Privnote.DAL.RepositoriesImpl;

public class NoteRepository : INoteRepository
{
    private readonly ApplicationContext _context;
    
    private readonly IMapper _mapper;

    public NoteRepository(ApplicationContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    
    public Task<Note?> GetAsync(Guid id)
    {
        return _context.Notes.Select(x => new Note()
        {
            Id = x.Id,
            Text = x.Text,
            CreatedAt = x.CreatedAt
        }).FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Note> CreateAsync(string text)
    {
        var newNote = new Entities.Note()
        {
            Id = new Guid(),
            Text = text,
            CreatedAt = DateTime.Now
        };

        await _context.Notes.AddAsync(newNote);
        await _context.SaveChangesAsync();

        return _mapper.Map<Note>(newNote);
    }

    public async Task DeleteAsync(Guid id)
    {
        try
        {
            var note = new Entities.Note()
            {
                Id = id
            };
            
            _context.Notes.Attach(note);
            _context.Notes.Remove(note);
            await _context.SaveChangesAsync();
            
        } catch (Exception ex) {
            if (!_context.Notes.Any(i => i.Id == id))
            {
                throw new EntityNotFoundException($"Deleted entity by id: {id} not found");
            }
                
            throw;
        }
    }
}