using System.IO.Abstractions.TestingHelpers;
using Xunit;
using ApprovalTests;
using ApprovalTests.Reporters;

namespace Hashor.App.Tests
{
    public class FileIngestTests
    {
        [Fact]
        [UseReporter(typeof(DiffReporter))]
        public void ReadsFile()
        {
            // Create Mock test file
            var mockFile = new MockFileData("Lorem ipsum dolor sit.");

            // Setup Mock File System with test file
            var mockFileSystem = new MockFileSystem();
            mockFileSystem.AddDirectory("tests");
            mockFileSystem.AddFile(@"tests/text.txt", mockFile);

            var fileIngestService = new FileIngestService(@"tests/text.txt", mockFileSystem);
            var file = fileIngestService.GetFileAsText();
            
            Assert.True(mockFileSystem.FileExists(@"tests/text.txt"));
            //Assert.Equal("Lorem ipsum dolor sit.", file);
            
            Approvals.Verify(file); // Uses app `Beyond Compare` or system diff tool to compare file with approved version 
        }
    }
}