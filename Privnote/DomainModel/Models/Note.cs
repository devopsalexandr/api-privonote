namespace Privnote.DomainModel.Models;

public class Note
{
    public Guid Id { get; set; }
    
    public string Text { get; set; }
    
    public DateTime CreatedAt { get; set; }
        
}