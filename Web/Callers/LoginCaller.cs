using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Web.Models;

namespace Web.Callers
{
    public class LoginCaller
    {
        private RestClient client;

        /// <summary>
        /// Creates the RestClient object using 'ProjectApi' path from web.config
        /// </summary>
        public LoginCaller()
        {
            client = new RestClient(ConfigurationManager.AppSettings["ProjectApi"]);
        }

        /// <summary>
        /// Uses the API to authenticate a users credentials
        /// </summary>
        /// <param name="email">Users email</param>
        /// <param name="password">Users encrypted password</param>
        /// <returns>A user if a users was found</returns>
        public async Task<Customer> GetByLogin(string email, string password)
        {
            var request = new RestRequest("api/customer/login", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddParameter("email", email);
            request.AddParameter("password", password);
            var response = await client.ExecuteAsync<Customer>(request);
            return response.Data;
        }
    }
}