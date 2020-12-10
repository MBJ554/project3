using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Models
{
    public class City
    {
        // TODO: review this section.. never used and name = nr in line 20
        private string cityName;

        private string zipCode;

        [DeserializeAs(Name = "navn")]
        public string CityName { get; set; }

        [DeserializeAs(Name = "nr")]
        public string ZipCode { get; set; }

        public City()
        {

        }
    }
}
