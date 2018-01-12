using System.ComponentModel;

namespace TryAgain.Models.Forms
{
    public class KursToPodanieFormModel
    {
        [DisplayName("Nazwa kursu")]
        public string NazwaKursu { get; set; }

        [DisplayName("Liczba punktów ECTS")]
        public int LiczbaEcts { get; set; }
    }
}