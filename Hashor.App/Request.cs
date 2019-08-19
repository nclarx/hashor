using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace Hashor.App
{
    public class Request
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