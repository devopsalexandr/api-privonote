namespace Privnote.DomainModel.Services.CryptService;

public interface IStringCryptService
{
    public string Encrypt(string text, string password);
    
    public string Decrypt(string text, string password);
}