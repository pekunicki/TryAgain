using System.ComponentModel.DataAnnotations;
using TryAgain.Models.Constants;

namespace TryAgain.Models.Forms
{
    public class PodanieFormModel
    {
        public string StudentOrganizujacyKurs { get; set; }

        [Required(ErrorMessage = "Pole kurs jest wymagane")]
        public KursToPodanieFormModel Kurs { get; set; }

        public RodzajKursu RodzajKursu { get; set; }

        [Required]
        public string ProponowanyProwadzacy { get; set; }

        [Required]
        public string Sala { get; set; }

        public DataToPodanieFormModel Data { get; set; }

        public PodanieFormModel()
        {
        }
    }
}
