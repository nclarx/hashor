using System;
using CommandLine;
using CommandLine.Text;

namespace Hashor.App
{
    public class HashOptions
    {
        
        [Option("stdin", HelpText = "A file path.")]
        public string Stdin { get; set; }
        
        [Verb("hash", HelpText = "Generate a hash of a file.")]
        public class HashFileOptions 
        { 
            
        }
        [Verb("sri", HelpText = "Generate a hash of a file for subresource integrity.")]
        public class SriOptions 
        {
            [Value(0, HelpText = "A path or URI to a document to be hashed")]
            public string Path { get; set; }

            [Option("algo", HelpText = "Selects the SHA512 algorithm.")]
            public string AlgorithmName { get; set; }
        }
        [Verb("list", HelpText = "List the hashes generated alongside their file paths.")]
        public class ListOptions 
        { 
            
        }
    }
}