using System;
using System.Linq.Expressions;
using System.Security.Authentication;
using System.Security.Permissions;

namespace Hashor.App
{
    public class AlgorithmUtility
    {
        public HashAlgorithmType GetAlgorithmType(string algorithmName)
        {
            switch (algorithmName)
            {
                case "sha256":
                    return HashAlgorithmType.Sha256;
                case "sha384":
                    return HashAlgorithmType.Sha384;
                case "sha512":
                    return HashAlgorithmType.Sha512;
                default:
                    return HashAlgorithmType.None;
            }
        }
    }
}