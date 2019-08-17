using System;
using System.Security.Authentication;
using System.Security.Cryptography;
using System.Text;
using hashor;
using Xunit;

namespace Hashor.App.Tests
{
    public class HashGenTests
    {
        [Fact]
        public void GetHash()
        {
            // Arrange
            var hasher = new HashGen(HashAlgorithmType.Sha512, Encoding.UTF8);

            // Act
            var hash = hasher.GetHash(
                "Lorem ipsum dolor sit sed a periculis cuntis. Liber e non sempre virgo gloriousa et benedicta.");
            
            // Assert
            Assert.IsType<string>(hash);
            Assert.NotNull(hash);

        }

        [Fact]
        public void HashGenInitialisation()
        {
            // Arrange
            var hashGenInstanceMd5 = new HashGen(HashAlgorithmType.Md5, Encoding.UTF8);
            var hashGenInstanceSha1 = new HashGen(HashAlgorithmType.Sha1, Encoding.UTF8);
            var hashGenInstanceSha256 = new HashGen(HashAlgorithmType.Sha256, Encoding.UTF8);
            var hashGenInstanceSha384 = new HashGen(HashAlgorithmType.Sha384, Encoding.UTF8);
            var hashGenInstanceSha512 = new HashGen(HashAlgorithmType.Sha512, Encoding.UTF8);
            
            // Assert
            
            // Check hash algos
            Assert.NotStrictEqual(MD5.Create(), hashGenInstanceMd5.hasher);
            Assert.IsType<SHA1Managed>(hashGenInstanceSha1.hasher);
            Assert.IsType<SHA256Managed>(hashGenInstanceSha256.hasher);
            Assert.IsType<SHA384Managed>(hashGenInstanceSha384.hasher);
            Assert.IsType<SHA512Managed>(hashGenInstanceSha512.hasher);
            
            // Check encoding
            Assert.Equal(Encoding.UTF8, hashGenInstanceSha512.inputEncoding);
        }
    }
}