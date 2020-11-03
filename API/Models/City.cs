using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
	public class City
	{
		public string zipCode { get; set; }
		public string city { get; set; }

		public City(string zipCode_, string city_)
		{
			this.zipCode = zipCode_;
			this.city = city_;
		}
        public City()
        {

        }
	}
}