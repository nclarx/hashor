using System;
using System.Runtime.CompilerServices;
using System.Security.Authentication;
using System.Security.Cryptography;
using System.Text;

namespace hashor
{
    public interface IHashStrategy
    {
        string GetHash(string text, Encoding enc, HashAlgorithm hashAlgorithm);
    }

    public class HashGen
    {
        private readonly HashAlgorithm _hasher;
        private readonly Encoding _inputEncoding;

        public HashGen(HashAlgorithmType hashAlgorithmType, Encoding enc)
        {
            _hasher = InitialiseHasher(hashAlgorithmType);
            _inputEncoding = enc;
        }

        public string GetHash(string text)
        {
            byte[] binaryString = EncodeToBytes(text);
            byte[] hash = _hasher.ComputeHash(binaryString);
            return Convert.ToBase64String(hash);
        }

        private byte[] EncodeToBytes(string text)
        {
            return _inputEncoding.GetBytes(text);
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