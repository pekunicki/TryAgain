using System;
using TryAgain.Models.Constants;

namespace TryAgain.Models
{
    internal class PotwierdzenieProwadzacegoModel
    {
        public string Link { get; set; }
        public StatusPotwierdzenia Status { get; set; }
        public int LiczbaDniWaznosciLinku { get; set; }
        public DateTime DataStworzenia { get; set; }
    }
}