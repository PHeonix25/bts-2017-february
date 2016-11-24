using System.Xml.Serialization;

namespace ConsoleApp1.DTOs
{
    public class Artist
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("url")]
        public string LastFmUri { get; set; }
    }
}