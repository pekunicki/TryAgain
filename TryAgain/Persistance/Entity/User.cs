using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TryAgain.Persistance.Entity
{
    public class User
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("imie")]
        public string  FirstName { get; set; }
        [Column("nazwisko")]
        public string LastName { get; set; }
        [Column("email")]
        public string Email { get; set; }
        [Column("haslo")]
        public string Password { get; set; }
        [Column("indeks")]
        public string Index { get; set; }
        [Column("rola")]
        public string Role { get; set; }

        public ICollection<Application> Applications { get; set; }

    }
}