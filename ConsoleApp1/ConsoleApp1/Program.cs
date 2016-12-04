using System;

using log4net;
using log4net.Config;

namespace ConsoleApp1
{
    static class Program
    {
        private static ILog _logger;

        static void Main(string[] args)
        {
            _logger = LogManager.GetLogger(typeof(Program));
            XmlConfigurator.Configure();

            LastFM.MakeWebRequest()
                .PrintMyTopTracks()
                .PrintWarningIfThereTracksLeft();

            try
            {
                throw new DivideByZeroException();
            }
            catch(Exception ex)
            {
                _logger.Fatal($"We caught an exception: {ex}");
            }

            Console.ReadLine();
        }
    }
}