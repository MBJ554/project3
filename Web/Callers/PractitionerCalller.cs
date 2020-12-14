using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Web.Models;

namespace Web.Controllers
{
    public class PractitionerCaller
    {
        private RestClient client;

        /// <summary>
        /// Creates the RestClient object using 'ProjectApi' path from web.config
        /// </summary>
        public PractitionerCaller()
        {
            client = new RestClient(ConfigurationManager.AppSettings["ProjectApi"]);
        }

        /// <summary>
        /// Gets practitioner by the 'practitionerURL' typically retrieved from another API result
        /// </summary>
        /// <param name="practitionerUrl">Practioner URL</param>
        /// <returns>Return a practitioner</returns>
        public async Task<Practitioner> GetPractitionerByURL(string practitionerUrl)
        {
            var request = new RestRequest(practitionerUrl, Method.GET);
            var response = await client.ExecuteAsync<Practitioner>(request);
            return response.Data;
        }
    }
}