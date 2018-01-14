using System;

namespace TryAgain.Utils.Extensions
{
    public static class TimeSpanExtensions
    {
        public static string GetHoursAndMinutes(this TimeSpan timespan)
        {
            return timespan.ToString(@"hh\:mm");
        }
    }
}