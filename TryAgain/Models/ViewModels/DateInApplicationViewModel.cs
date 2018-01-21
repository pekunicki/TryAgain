using TryAgain.Models.Constants;
using DayOfWeek = TryAgain.Models.Constants.DayOfWeek;

namespace TryAgain.Models.ViewModels
{
    public class DateInApplicationViewModel
    {
        public DayOfWeek Day { get; set; }
        public WeekType Week { get; set; }

        public string StartTime { get; set; }
        public string EndTime{ get; set; }
    }
}