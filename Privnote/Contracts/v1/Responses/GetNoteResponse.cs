namespace Privnote.Contracts.v1.Responses;

public class GetNoteResponse
{
    public Guid Id { get; set; }
    
    public string Text { get; set; }
    
    public DateTime CreatedAt { get; set; }
}