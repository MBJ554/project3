using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
	public class Injury
	{
		public int Id { get; set; }
		public int CustomerId { get; set; }
		public int InjuryTypeId { get; set; }
		public string Description { get; set; }
		public string Severity { get; set; }

		public Injury(int id_, int customerId_, int injuryTypeId_, string description_, string severity_)
		{
			this.Id = id_;
			this.CustomerId = customerId_;
			this.InjuryTypeId = injuryTypeId_;
			this.Description = description_;
			this.Severity = severity_;
		}

		public Injury()
        {

        }
	}
}