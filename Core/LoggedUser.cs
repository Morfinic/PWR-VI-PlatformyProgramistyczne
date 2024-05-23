using DeviceId;

namespace PWR_VI_PodPro.Core
{
    public class LoggedUser
    {
        public static string DeviceId { get; set; }
        public static string? Email { get; set; }

        public static void InitUser()
        {
            DeviceId = new DeviceIdBuilder()
                .AddMachineName()
                .AddOsVersion()
                .AddUserName()
                .ToString();
            Email = String.Empty;
        }
    }
}
