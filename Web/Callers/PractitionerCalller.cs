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


        public PractitionerCaller()
        {

            client = new RestClient(ConfigurationManager.AppSettings["ProjectApi2"]);
        }

        public async Task<Practitioner> GetPractitionerId(string practitionerUrl)
        {
            var request = new RestRequest(practitionerUrl, Method.GET);
            var response = await client.ExecuteAsync<Practitioner>(request);
            return response.Data;
        }


    }
}