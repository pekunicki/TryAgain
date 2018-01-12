using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using TryAgain.Models.Constants;

namespace TryAgain.Models.Forms
{
    public class DataToPodanieFormModel
    {
        public DzienTygodnia Dzien { get; set; }
        public RodzajTygodnia Tydzien { get; set; }
        public TimeSpan GodzinaRozpoczecia { get; set; }
        public TimeSpan GodzinaZakoczenia { get; set; }
        public List<SelectListItem> AvailableHours { get; set; }
        public List<SelectListItem> AvailableMinutes { get; set; }

        public DataToPodanieFormModel()
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