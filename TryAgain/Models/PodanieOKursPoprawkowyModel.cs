using System;
using Microsoft.AspNetCore.Mvc;
using TryAgain.Models.Constants;

namespace TryAgain.Models
{
    internal class PodanieOKursPoprawkowyModel
    {
        public StatusPodania Status { get; set; }
        public string Sala { get; set; }
        public TimeSpan GodzinaRozpoczecia { get; set; }
        public TimeSpan GodzinaZakonczenia { get; set; }
        public RodzajTygodnia Tydzien { get; set; }
        public DayOfWeek DzienTygodnia { get; set; }
    }
}