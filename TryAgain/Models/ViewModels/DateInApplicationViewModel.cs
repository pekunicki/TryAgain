using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using TryAgain.Models.Constants;
using DayOfWeek = TryAgain.Models.Constants.DayOfWeek;

namespace TryAgain.Models.ViewModels
{
    public class DateInApplicationViewModel
    {
        private TimeSpan _godzinaRozpoczecia;
        private TimeSpan _godzinaZakonczenia;

        public DayOfWeek Day { get; set; }
        public WeekType Week { get; set; }

        public string StartTime { get; set; }
        public string EndTime{ get; set; }

        public List<SelectListItem> AvailableHours { get; set; }
        public List<SelectListItem> AvailableMinutes { get; set; }

        public DateInApplicationViewModel()
        {
            AvailableHours = GetListOfIntegers(0, 23);
            AvailableMinutes = GetListOfIntegers(0, 59);
        }

        private List<SelectListItem> GetListOfIntegers(int start, int stop)
        {
            return Enumerable.Range(start, stop)
                .Select(c => new SelectListItem { Text = c.ToString(), Value = c.ToString() })
                .ToList();
        }
    }
}