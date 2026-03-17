namespace Common.EncriptyPass.Logic.Interfaces;

public interface IIncryptService
{
    string Encrypt(string password);
    bool Verify(string password, string encryptedPassword);
    string Decrypt(string encryptedPassword);
}