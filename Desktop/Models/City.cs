using RestSharp.Deserializers;

namespace Desktop.Models
{
    public class City
    {
        public string Navn { get { return cityName; } set { cityName = value; } }
        private string cityName;
        //[DeserializeAs(Name = "navn")]
        public string CityName { get { return cityName; } set { cityName = value; } }

        public string Nr { get { return zipCode; } set { zipCode = value; } }
        //[DeserializeAs(Name = "nr")]
        private string zipCode;
        public string ZipCode { get { return zipCode; } set { zipCode = value; } }

        public City()
        {
        }
    }
}