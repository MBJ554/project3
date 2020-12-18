namespace API.ApiHelpers
{
    public static class ApiHelper
    {
        public static string BuildCustomerURL(int id)
        {
            return "/api/customer/" + id;
        }

        public static string BuildClinicURL(int id)
        {
            return "/api/clinic/" + id;
        }

        public static string BuildPractitionerURL(int id)
        {
            return "/api/practitioner/" + id;
        }

        public static string BuildCityURL(int id)
        {
            return "/api/city/" + id;
        }

        public static string BuildExerciseURL(int id)
        {
            return "/api/exercise/" + id;
        }

        public static string BuildInjuryTypeURL(int id)
        {
            return "/api/injuryType/" + id;
        }

        public static string BuildRehabProgramURL(int id)
        {
            return "/api/rehabProgam/" + id;
        }
    }
}