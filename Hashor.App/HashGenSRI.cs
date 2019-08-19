using System.Security.Authentication;
using System.Text;

namespace Hashor.App
{
    public class HashGenSri : HashGen
    {
        public readonly string HashPrefix;
        public readonly string HashDigest;
        


        public HashGenSri(HashAlgorithmType hashAlgorithmType, 
            Encoding enc, string inputText) : base(hashAlgorithmType, enc)
        {
            HashPrefix = hashAlgorithmType.ToString().ToLower() + "-";
            HashDigest = GetHash(inputText);
        }

        public new string GetHash(string text)
        {
            string hash = base.GetHash(text);
            return HashPrefix + hash;
        }
    }
}