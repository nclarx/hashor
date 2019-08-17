using System;
using System.Security.Authentication;
using System.Text;
using Hashor.App;

namespace hashor
{
    public class HashGenSri : HashGen
    {
        private string hashPrefix;

        public HashGenSri(HashAlgorithmType hashAlgorithmType, Encoding enc) : base(hashAlgorithmType, enc)
        {
            hashPrefix = hashAlgorithmType.ToString();
        }

        public new string GetHash(string text)
        {
            var hash = base.GetHash(text);
            return hashPrefix.ToLower() + "-" + hash;
        }
    }
}