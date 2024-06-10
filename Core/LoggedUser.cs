using DeviceId;

namespace PWR_VI_PodPro.Core
{
    /// <summary>
    /// Logika zalogowanego użytkownika
    /// </summary>
    public class LoggedUser
    {
        public static string DeviceId { get; set; }
        public static string? Email { get; set; }

        /// <summary>
        /// Funkcja inicjalizująca obiekt użytkownika
        /// </summary>
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
