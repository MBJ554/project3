using RestSharp.Deserializers;

namespace Desktop.Models
{
    public class City
    {
        [DeserializeAs(Name = "navn")]
        public string CityName { get; set; }

        [DeserializeAs(Name = "nr")]
        public string ZipCode { get; set; }

        public City()
        {
        }
    }
}