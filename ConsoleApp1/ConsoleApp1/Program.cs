using System;
using System.Linq;

using ConsoleApp1.DTOs;

namespace ConsoleApp1
{
    static class Program
    {
        const string LAST_FM_API_ENDPOINT = "http://ws.audioscrobbler.com/2.0/";
        const string LAST_FM_API_KEY = "48308a6b32cf819c13aa999383c36985";
        const string LAST_FM_MY_USERNAME = "pheonix25";

        static void Main(string[] args)
        {
            MakeWebRequest().DisplaySomeStats();
            Console.ReadLine();
        }

        private static TopTracks MakeWebRequest()
        {
            var query = $"?method=user.gettoptracks&user={LAST_FM_MY_USERNAME}&api_key={LAST_FM_API_KEY}";
            Console.WriteLine($"Querying: {query} from LastFM.");
            
            var requester = new Requester(new Uri(LAST_FM_API_ENDPOINT));
            var result = requester.Request<LastFmResponse>(query).Result;
            Console.WriteLine($"Request returned response code: {result.ResponseStatus}");
            return result.Response;
        }

        private static void DisplaySomeStats(this TopTracks result)
        {
            Console.WriteLine();
            Console.WriteLine("Printing a list of my 10 most 'scrobbled' tracks");
            Console.WriteLine("------------------------------------------------");
            foreach(var track in result.Tracks.Take(10))
                Console.WriteLine($"{track.Rank}:\t'{track.Name}' by {track.Artist.Name}.");
            Console.WriteLine("------------------------------------------------");
        }

        // http://ws.audioscrobbler.com/2.0/?method=user.gettoptracks&user=pheonix25&api_key=48308a6b32cf819c13aa999383c36985
    }
}