using System.Xml.Serialization;

namespace ConsoleApp1.DTOs
{
    [XmlRoot("lfm")]
    public class LastFmResponse
    {
        [XmlAttribute("status")]
        public LastFmStatusResponseCode ResponseStatus { get; set; }

        [XmlElement("toptracks")]
        public TopTracks Response { get; set; }
    }
}