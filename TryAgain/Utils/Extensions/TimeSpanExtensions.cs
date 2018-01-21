using System;
using System.Globalization;

namespace TryAgain.Utils.Extensions
{
    public static class TimeSpanExtensions
    {
        public static string GetHoursAndMinutes(this TimeSpan timespan)
        {
            return timespan.ToString(@"hh\:mm");
        }

        public static TimeSpan? TryParseToTimeSpan(this string time)
        {
            var formats = new[] { @"hh\:mm", @"hh\:mm\:ss" };

            if (TimeSpan.TryParseExact(time, formats, CultureInfo.InvariantCulture, out var value))
            {
                if (value.Hours >= 0
                    && value.Minutes >= 0
                    && value.Days == 0
                    && value.Seconds >= 0
                    && value.Milliseconds == 0)
                {
                    return value;
                }
            }
            return null;
        }
    }
}
