namespace Privnote.DomainModel.Models;

public class Note
{
    public Guid Id { get; set; }
    
    public string Text { get; set; }
    
    public int ReadAttempts { get; set; }
    
    public DateTime CreatedAt { get; set; }
        
}