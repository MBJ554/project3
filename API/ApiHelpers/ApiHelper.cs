using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace API.ApiHelpers
{
    public static class ApiHelper
    {

        private static string BaseURL = "https://localhost:44375/";
        public static string BuildCustomerURL(int id)
        {
            return BaseURL + "api/customer/" + id;
        }

        public static string BuildClinicURL(int id)
        {
            return BaseURL + "api/clinic/" + id;
        }

        public static string BuildPractitionerURL(int id)
        {
            return BaseURL + "api/practitioner/" + id;
        }
        public static string BuildCityURL(int id)
        {
            return BaseURL + "api/city/" + id;
        }
        
        public static string BuildExerciseURL(int id)
        {
            return BaseURL + "api/exercise/" + id;
        }
        public static string BuildInjuryTypeURL(int id)
        {
            return BaseURL + "api/injuryType/" + id;
        }

        public static string BuildRehabProgramURL(int id)
        {
            return BaseURL + "api/rehabProgam/" + id;
        }


    }
}