using TryAgain.Models.Constants;

namespace TryAgain.Models.Forms
{
    public class PodanieViewModel
    {
        public string StudentOrganizujacyKurs { get; set; }

        public KursToPodanieViewModel Kurs { get; set; }

        public RodzajKursu RodzajKursu { get; set; }

        public string ProponowanyProwadzacy { get; set; }

        public string Sala { get; set; }

        public DataToPodanieViewModel Data { get; set; }

        public PodanieViewModel()
        {

        }
    }
}
