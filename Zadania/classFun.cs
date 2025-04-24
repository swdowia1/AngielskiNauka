namespace Zadania
{
    public class classFun
    {
        public static DateTime DateNow()
        {
            return DateTime.UtcNow;

        }

        internal static Dictionary<string, object> CreatePrameter(string nameParameter, int val)
        {
            if (!nameParameter.StartsWith("@"))
                nameParameter = "@" + nameParameter;
            return new Dictionary<string, object> { { nameParameter, val } };
        }

        internal static string TimeHourMinute(int totalSeconds)
        {
            TimeSpan time = TimeSpan.FromMinutes(totalSeconds);
            return $"{(int)time.TotalHours:D2}:{time.Minutes:D2}";
        }
    }
}
