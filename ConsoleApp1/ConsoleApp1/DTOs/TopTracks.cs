using System.Collections.Generic;
using System.Xml.Serialization;

namespace ConsoleApp1.DTOs
{
    public class TopTracks
    {
        [XmlAttribute("user")]
        public string UserName { get; set; }

        [XmlAttribute("page")]
        public int Page { get; set; }

        [XmlAttribute("perPage")]
        public int PerPage { get; set; }

        [XmlAttribute("totalPages")]
        public int TotalPages { get; set; }

        [XmlAttribute("total")]
        public int TotalTracks { get; set; }

        [XmlElement("track")]
        public List<Track> Tracks;
    }
}