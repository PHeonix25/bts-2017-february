using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleApp1
{
    public class Requester
    {
        private readonly Uri _uri;

        public Requester(Uri baseUri)
        {
            _uri = baseUri;
        }

        public async Task<T> Request<T>(string request) where T : class
        {
            using(var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = _uri;
                    var response = await client.GetAsync(request);
                    response.EnsureSuccessStatusCode();

                    var streamResponse = await response.Content.ReadAsStreamAsync();
                    var serializer = new XmlSerializer(typeof(T));
                    var result = serializer.Deserialize(streamResponse) as T;

                    return result;
                }
                catch(HttpRequestException e)
                {
                    Console.WriteLine($"HTTP Request exception: {e.Message}");
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"Exception generated during request: {ex}");
                }
            }
            return default(T);
        }
    }
}