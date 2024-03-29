using System;
using System.Security.Authentication;
using System.Security.Cryptography;
using System.Text;

namespace Hashor.App
{
    public interface IHashStrategy
    {
        string GetHash(string text, Encoding enc, HashAlgorithm hashAlgorithm);
    }

    public class HashGen
    {
        public readonly HashAlgorithm Hasher;
        public readonly Encoding InputEncoding;

        public HashGen(HashAlgorithmType hashAlgorithmType, Encoding enc)
        {
            Hasher = InitialiseHasher(hashAlgorithmType);
            InputEncoding = enc;
        }

        public string GetHash(string text)
        {
            byte[] binaryString = EncodeToBytes(text);
            byte[] hash = Hasher.ComputeHash(binaryString);
            return Convert.ToBase64String(hash);
        }

        private byte[] EncodeToBytes(string text)
        {
            return InputEncoding.GetBytes(text);
        }

        private static HashAlgorithm InitialiseHasher(HashAlgorithmType hashAlgorithmType)
        {
            switch (hashAlgorithmType)
            {
                case HashAlgorithmType.Md5:
                    return MD5.Create();
                case HashAlgorithmType.Sha1:
                    return new SHA1Managed();
                case HashAlgorithmType.Sha256:
                    return new SHA256Managed();
                case HashAlgorithmType.Sha384:
                    return new SHA384Managed();
                case HashAlgorithmType.Sha512:
                    return new SHA512Managed();
                case HashAlgorithmType.None:
                    throw new ArgumentOutOfRangeException(nameof(hashAlgorithmType), hashAlgorithmType,
                        "A hash algorithm was not provided");
                default:
                    throw new ArgumentOutOfRangeException(nameof(hashAlgorithmType), hashAlgorithmType,
                        "A valid hash algorithm was not provided");
            }
        }
    }
}