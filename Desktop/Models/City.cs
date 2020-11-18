using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Models
{
    public class City
    {

        private string cityName;

        private string zipCode;

        public string CityName { get { return cityName; } set { cityName = value; } }
        public string ZipCode { get; set; }

        public string navn { 
            get 
            { 
                return cityName; 
            } 
            set 
            { 
                cityName = value; 
            } 
        }

        public string nr { 
            get 
            {
                return zipCode;
            } 
            set 
            { 
                zipCode = value; 
            } 
        }

        public City() { 
        
        }
    }
}
