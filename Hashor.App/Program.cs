using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using CommandLine.Text;
using hashor;

namespace Hashor.App
{
    class Program
    {
        
        /*[Verb("sri", HelpText = "Utility for generating subresource integrity hashes.")]
        class AddOptions {
            //normal options here
        }*/
        public class Options
        {
            
            [Usage(ApplicationAlias = "Hasher")]
            public static IEnumerable<Example> Examples
            {
                get
                {
                    return new List<Example>() {
                        new Example("Convert file to a trendy format", new Options {  })
                    };
                }
            }
            
            [Option('h', "help", Required = false, HelpText = "Displays help documentation.")]
            public bool Help { get; set; }

            [Option("stdin", Default = false, HelpText = "Read from stdin")]
            public bool stdin { get; set; }
        }

        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed<Options>(o =>
                {
                    if (o.Help)
                    {
                        Console.WriteLine($"Verbose output enabled. Current Arguments: -v {o.Help}");
                        Console.WriteLine("Quick Start Example! App is in Verbose mode!");
                    }
                    else
                    {
                        Console.WriteLine($"Current Arguments: -v {o.Help}");
                        Console.WriteLine("Quick Start Example!");
                    }
                });
            

            Console.WriteLine("Provide a URI to be hashed:");
            var input = Console.ReadLine();
            
            if(input == null) throw new ArgumentNullException();

            try
            {
                var requester = new Request();
                var result = requester.GetPage(input);
                Console.WriteLine(result.Result);
                var hasher = new HashGenSri(HashAlgorithmType.Sha512, Encoding.UTF8);
                var hash = hasher.GetHash(result.Result);
                Console.WriteLine(hash);
                // File.WriteAllText("./index.html", hash);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }

    class Request
    {
        public Task<string> GetPage(string url)
        {
            return GetAsyncHttp(url);
        }

        private async Task<string> GetAsyncHttp(string uri)
        {
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(uri);
            request.Method = WebRequestMethods.Http.Get;

            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse) await request.GetResponseAsync())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return await reader.ReadToEndAsync();
            }
        }
    }
}