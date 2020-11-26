using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.DAL.Models
{
	public class City
	{
		public string ZipCode { get; set; }
		public string CityName { get; set; }

		public City(string _zipCode, string _cityName)
		{
			this.ZipCode = _zipCode;
			this.CityName = _cityName;
		}
		public City()
		{

		}
	}
}