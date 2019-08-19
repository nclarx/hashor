using System.Security.Authentication;
using System.Text;
using Xunit;

namespace Hashor.App.Tests
{
    public class HashGenSriTests
    {

        [Fact]
        public void HashPrefixInitialisation()
        {
            var hashSri = new HashGenSri(HashAlgorithmType.Sha512, Encoding.UTF8, "Hello there");
            Assert.Equal("sha512-", hashSri.HashPrefix);
        }

        [Fact]
        public void GetHashTest()
        {
            var hashSri = new HashGenSri(HashAlgorithmType.Sha512, Encoding.UTF8, "Hello there");

            // TODO: get rid of public getHash method and replace with HashDigest public field
            var result = hashSri.GetHash("Lorem ipsum dolor sit.");

            Assert.Contains("sha512-", result);
        }
        
        
        
    }
}