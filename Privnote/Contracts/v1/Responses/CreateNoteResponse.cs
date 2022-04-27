namespace Privnote.Contracts.v1.Responses;

public class CreateNoteResponse
{
    public Guid Id { get; set; }
    
    public DateTime CreatedAt { get; set; }
}