using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using CommandLine.Text;

namespace Hashor.App
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Provide path to text for hashing:");

            try
            {
                string input = Console.ReadLine();
                HashGenSri hasher = new HashGenSri(HashAlgorithmType.Sha512, Encoding.UTF8);
                string hash = hasher.GetHash(input);
                Console.WriteLine(hash);
                File.AppendAllText("./hashes.txt", hash + "\n");
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