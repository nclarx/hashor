using System.Security.Authentication;
using System.Text;

namespace Hashor.App
{
    public class HashGenSri : HashGen
    {
        public readonly string HashPrefix;

        public HashGenSri(HashAlgorithmType hashAlgorithmType, Encoding enc) : base(hashAlgorithmType, enc)
        {
            HashPrefix = hashAlgorithmType.ToString().ToLower() + "-";
        }

        public new string GetHash(string text)
        {
            string hash = base.GetHash(text);
            return HashPrefix + hash;
        }
    }
}