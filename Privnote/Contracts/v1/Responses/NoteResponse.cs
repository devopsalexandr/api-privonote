namespace Privnote.Contracts.v1.Responses;

public class NoteResponse
{
    public Guid Id { get; set; }
    
    public string Text { get; set; }
    
    public DateTime CreatedAt { get; set; }
}