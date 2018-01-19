using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using TryAgain.Models.Constants;

namespace TryAgain.Persistance.Entity
{
    public class Course
    {
        [Column("idkursu")]
        public int Id { get; set; }
        [Column("nazwakursu")]
        public string CourseName { get; set; }
        [Column("punktyects")]
        public int Ects { get; set; }
        [Column("rodzaj")]
        public CourseType Type { get; set; }

        public ICollection<Application> Applications { get; set; }

    }
}
