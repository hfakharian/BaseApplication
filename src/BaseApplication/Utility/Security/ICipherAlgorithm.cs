namespace Utility.Security
{
    public interface ICipherAlgorithm
    {
        string EncryptString(string plainText);
        string DecryptString(string cipherText);
    }
}
