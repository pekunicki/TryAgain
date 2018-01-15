using System;
using Microsoft.AspNetCore.Mvc;
using TryAgain.Models.Constants;
using DayOfWeek = System.DayOfWeek;

namespace TryAgain.Models
{
    internal class PodanieOKursPoprawkowyModel
    {
        public ApplicationState Status { get; set; }
        public string Sala { get; set; }
        public TimeSpan GodzinaRozpoczecia { get; set; }
        public TimeSpan GodzinaZakonczenia { get; set; }
        public WeekType Tydzien { get; set; }
        public DayOfWeek DzienTygodnia { get; set; }
    }
}