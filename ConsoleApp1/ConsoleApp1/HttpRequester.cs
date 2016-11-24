using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;

using log4net;
using log4net.Config;

namespace ConsoleApp1
{
    public class Requester
    {
        private readonly Uri _uri;
        private readonly ILog _logger;

        public Requester(Uri baseUri)
        {
            _uri = baseUri;
            _logger = LogManager.GetLogger(typeof(Requester));
            XmlConfigurator.Configure();
        }

        public async Task<T> Request<T>(string request) where T : class
        {
            using(var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = _uri;

                    _logger.Debug($"Requesting {request} from '{_uri}'");
                    var response = await client.GetAsync(request);
                    response.EnsureSuccessStatusCode();
                    _logger.Debug($"Request completed with statuscode {response.StatusCode}.");

                    var streamResponse = await response.Content.ReadAsStreamAsync();
                    var serializer = new XmlSerializer(typeof(T));
                    var result = serializer.Deserialize(streamResponse) as T;
                    _logger.Debug($"Response was deserialised correctly into '{typeof(T)}'.");

                    return result;
                }
                catch(HttpRequestException e)
                {
                    _logger.Error($"HTTP Request exception: {e.Message}");
                }
                catch(Exception ex)
                {
                    _logger.Error($"Exception generated during request: {ex}");
                }
            }
            return default(T);
        }
    }
}