using System;

namespace TryAgain.Models.Forms
{
    public static class TimeSpanExtensions
    {
        public static string GetHoursAndMinutes(this TimeSpan timespan)
        {
            return timespan.ToString(@"hh\:mm");
        }
    }
}