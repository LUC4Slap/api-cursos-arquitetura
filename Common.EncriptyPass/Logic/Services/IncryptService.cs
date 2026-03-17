using Common.EncriptyPass.Logic.Interfaces;

namespace Common.EncriptyPass.Logic.Services;

public class IncryptService : IIncryptService
{
    public string Encrypt(string password)
    {
        try
        {
            var senhaHash = BCrypt.Net.BCrypt.HashPassword(password);
            return senhaHash;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public bool Verify(string password, string encryptedPassword)
    {
        try
        {
            var senhaValida = BCrypt.Net.BCrypt.Verify(password, encryptedPassword);
            return senhaValida;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public string Decrypt(string encryptedPassword)
    {
        throw new NotImplementedException();
    }
}