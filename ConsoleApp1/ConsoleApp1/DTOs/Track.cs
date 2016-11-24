using System.Xml.Serialization;

namespace ConsoleApp1.DTOs
{
    public class Track
    {
        [XmlAttribute("rank")]
        public int Rank { get; set; }

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("playcount")]
        public int PlayCount { get; set; }

        [XmlElement("artist")]
        public Artist Artist { get; set; }
    }
}