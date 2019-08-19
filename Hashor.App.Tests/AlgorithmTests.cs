using System.Security.Authentication;
using System.Text;
using Xunit;

namespace Hashor.App.Tests
{
    public class AlgorithmTests
    {
        [Fact]
        public void GetsAlgorithmType()
        {
            var algorithmChecker = new AlgorithmUtility();

            // Test algorithm name strings 
            var sha256 = algorithmChecker.GetAlgorithmType("sha256");
            var sha384 = algorithmChecker.GetAlgorithmType("sha384");
            var sha512 = algorithmChecker.GetAlgorithmType("sha512");
            
            // Assert that correct HashAlgorithmType is returned
            Assert.Equal(HashAlgorithmType.Sha256, sha256);
            Assert.Equal(HashAlgorithmType.Sha384, sha384);
            Assert.Equal(HashAlgorithmType.Sha512, sha512);
        }
    }
}