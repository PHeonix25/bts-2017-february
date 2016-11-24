using System;
using System.Linq;

using ConsoleApp1.DTOs;

using log4net;
using log4net.Config;

namespace ConsoleApp1
{
    static class Program
    {
        const string LAST_FM_API_ENDPOINT = "http://ws.audioscrobbler.com/2.0/";
        const string LAST_FM_API_KEY = "48308a6b32cf819c13aa999383c36985";
        const string LAST_FM_MY_USERNAME = "pheonix25";
        private static ILog _logger;

        static void Main(string[] args)
        {
            _logger = LogManager.GetLogger(typeof(Program));
            XmlConfigurator.Configure();

            try
            {
                MakeWebRequest().DisplaySomeStats();
                throw new DivideByZeroException();
            }
            catch(Exception ex)
            {
                _logger.Fatal($"Something went wrong: {ex}");
            }

            Console.ReadLine();
        }

        private static TopTracks MakeWebRequest()
        {
            var query = $"?method=user.gettoptracks&user={LAST_FM_MY_USERNAME}&api_key={LAST_FM_API_KEY}";
            _logger.Info($"Querying: {query} from LastFM.");

            var requester = new Requester(new Uri(LAST_FM_API_ENDPOINT));
            var result = requester.Request<LastFmResponse>(query).Result;

            _logger.InfoFormat("Request returned response code: {0}", result.ResponseStatus);

            return result.Response;
        }

        private static void DisplaySomeStats(this TopTracks result, int trackCount = 10)
        {
            Console.WriteLine();
            _logger.Info("Printing a list of my 10 most 'scrobbled' tracks");
            Console.WriteLine("------------------------------------------------");
            foreach(var track in result.Tracks.Take(trackCount))
                _logger.Info($"{track.Rank}:\t'{track.Name}' by {track.Artist.Name}.");
            Console.WriteLine("------------------------------------------------");
            _logger.Warn($"There are {result.TotalTracks - trackCount} other tracks not shown above.");
        }
    }
}