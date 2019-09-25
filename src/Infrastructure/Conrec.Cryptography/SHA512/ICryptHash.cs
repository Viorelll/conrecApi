namespace Conrec.Cryptography.SHA512
{
    public interface ICryptHash
    {
        string ComputeHash(string plainText, byte[] saltBytes);
        bool VerifyHash(string plainText, string hashValue);
    }
}
