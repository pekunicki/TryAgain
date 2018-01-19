using System;
using System.ComponentModel.DataAnnotations.Schema;
using TryAgain.Models.Constants;

namespace TryAgain.Persistance.Entity
{
    public class TeacherConfirmation
    {
        [Column("idpotwierdzenia")]
        public int Id { get; set; }
        [Column("idpodania")]
        public int ApplicationId { get; set; }
        [Column("idprowadzacego")]
        public int TeacherId { get; set; }
        [Column("link")]
        public string Link { get; set; }
        [Column("status")]
        public ConfirmationState State { get; set; }
        [Column("iloscdniwaznoscilinku")]
        public int ExpiryDaysNumber { get; set; }
        [Column("datastworzenia")]
        public DateTime CreationDate { get; set; }

        public Teacher Teacher { get; set; }
        public Application Application { get; set; }
    }
}