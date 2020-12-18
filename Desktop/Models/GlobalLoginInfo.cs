namespace Desktop.Models
{
    public static class GlobalLoginInfo
    {
        public static int UserId { get; set; }
        public static string FullName { get; set; }

        public static int ClinicId { get; set; }
        public static Clinic Clinic { get; set; }
    }
}