using System;

namespace NTCSAttendanceKiosk
{
    public static class SqlConnectionInfo
    {
        public static string ConnectionString { get; set; }
        public static string KioskLocation { get; set; }

        public static void LogError(string message)
        {

        }
    }
}
