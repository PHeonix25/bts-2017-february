using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConsoleApp1.DTOs;

using log4net;
using log4net.Config;

namespace ConsoleApp1
{
    static class LastFM
    {
        private static readonly ILog _logger;
        const string LAST_FM_API_ENDPOINT = "http://ws.audioscrobbler.com/2.0/";
        const string LAST_FM_METHODNAME = "user.gettoptracks";
        const string LAST_FM_APIKEY = "48308a6b32cf819c13aa999383c36985";
        const string LAST_FM_USERNAME = "pheonix25";

        static LastFM()
        {
            _logger = LogManager.GetLogger(typeof(LastFM));
            XmlConfigurator.Configure();
        }

        public static TopTracks MakeWebRequest()
        {
            var query = $"?method={LAST_FM_METHODNAME}&user={LAST_FM_USERNAME}&api_key={LAST_FM_APIKEY}";
            _logger.Info($"Querying: {query} from LastFM.");

            var requester = new Requester(new Uri(LAST_FM_API_ENDPOINT));
            var result = requester.Request<LastFmResponse>(query).Result;

            _logger.Info($"Request returned response code: {result.ResponseStatus}");

            return result.Response;
        }

        public static IEnumerable<Track> PrintMyTopTracks(this TopTracks result, int trackCount = 10)
        {
            Console.WriteLine();
            _logger.Info($"Printing a list of my {trackCount} most 'scrobbled' tracks");
            Console.WriteLine("------------------------------------------------");

            foreach (var track in result.Tracks.Take(trackCount))
                _logger.Info($"{track.Rank}:\t'{track.Name}' by {track.Artist.Name}.");

            Console.WriteLine("------------------------------------------------");
            return result.Tracks.Skip(trackCount);
        }

        public static void PrintWarningIfThereAreTracksLeft(this IEnumerable<Track> tracks)
        {
            _logger.Warn($"There are {tracks.Count()} other tracks not shown.");
        }
    }
}
