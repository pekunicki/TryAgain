using System.ComponentModel.DataAnnotations.Schema;

namespace TryAgain.Persistance.Entity
{
    public class Teacher
    {
        [Column("idprowadzacego")]
        public int Id { get; set; }
        [Column("iloscgodzin")]
        public string HoursNumber { get; set; }
        [Column("email")]
        public string Email { get; set; }
        [Column("imie")]
        public string FirstName { get; set; }
        [Column("nazwisko")]
        public string LastName { get; set; }
    }
}