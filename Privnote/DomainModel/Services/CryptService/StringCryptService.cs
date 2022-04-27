using System.Security.Cryptography;
using System.Text;
using Privnote.DomainModel.Services.CryptService.Exceptions;

namespace Privnote.DomainModel.Services.CryptService;

public class StringCryptService : IStringCryptService
{
    private readonly string _password;
    
    public StringCryptService()
    {
    }
    
    public StringCryptService(string password)
    {
        _password = password ?? throw new ArgumentNullException(nameof(password));
    }
    public string Encrypt(string text)
    {
        var password = _password ?? throw new NullPasswordException();
        return EncryptString(text, password);
    }

    public string Decrypt(string text)
    {
        var password = _password ?? throw new NullPasswordException();
        return DecryptString(text, password);
    }
    
    public string Encrypt(string text, string password)
    {
        return DecryptString(text, password);
    }

    public string Decrypt(string text, string password)
    {
        return DecryptString(text, password);
    }

    private static string EncryptString(string text, string password)
    {
        byte[] toEncryptedArray = UTF8Encoding.UTF8.GetBytes(text);

        MD5CryptoServiceProvider objMD5CryptoService = new MD5CryptoServiceProvider();
        //Gettting the bytes from the Security Key and Passing it to compute the Corresponding Hash Value.
        byte[] securityKeyArray = objMD5CryptoService.ComputeHash(UTF8Encoding.UTF8.GetBytes(password));
        //De-allocatinng the memory after doing the Job.
        objMD5CryptoService.Clear();

        var objTripleDesCryptoService = new TripleDESCryptoServiceProvider();
        //Assigning the Security key to the TripleDES Service Provider.
        objTripleDesCryptoService.Key = securityKeyArray;
        //Mode of the Crypto service is Electronic Code Book.
        objTripleDesCryptoService.Mode = CipherMode.ECB;
        //Padding Mode is PKCS7 if there is any extra byte is added.
        objTripleDesCryptoService.Padding = PaddingMode.PKCS7;


        var objCrytpoTransform = objTripleDesCryptoService.CreateEncryptor();
        //Transform the bytes array to resultArray
        byte[] resultArray = objCrytpoTransform.TransformFinalBlock(toEncryptedArray, 0, toEncryptedArray.Length);
        objTripleDesCryptoService.Clear();
        return Convert.ToBase64String(resultArray, 0, resultArray.Length);
    }

    private static string DecryptString(string text, string password)
    {
        byte[] toEncryptArray = Convert.FromBase64String(text);
        MD5CryptoServiceProvider objMD5CryptoService = new MD5CryptoServiceProvider();

        //Gettting the bytes from the Security Key and Passing it to compute the Corresponding Hash Value.
        byte[] securityKeyArray = objMD5CryptoService.ComputeHash(UTF8Encoding.UTF8.GetBytes(password));
        objMD5CryptoService.Clear();

        var objTripleDESCryptoService = new TripleDESCryptoServiceProvider();
        //Assigning the Security key to the TripleDES Service Provider.
        objTripleDESCryptoService.Key = securityKeyArray;
        //Mode of the Crypto service is Electronic Code Book.
        objTripleDESCryptoService.Mode = CipherMode.ECB;
        //Padding Mode is PKCS7 if there is any extra byte is added.
        objTripleDESCryptoService.Padding = PaddingMode.PKCS7;

        var objCrytpoTransform = objTripleDESCryptoService.CreateDecryptor();
        //Transform the bytes array to resultArray
        byte[] resultArray = objCrytpoTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
        objTripleDESCryptoService.Clear();

        //Convert and return the decrypted data/byte into string format.
        return UTF8Encoding.UTF8.GetString(resultArray);
    }
}