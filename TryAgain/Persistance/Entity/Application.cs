using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using TryAgain.Models.Constants;
using DayOfWeek = TryAgain.Models.Constants.DayOfWeek;

namespace TryAgain.Persistance.Entity
{
    public class Application
    {
        [Column("idpodania")]
        public int Id { get; set; }
        [Column("idstudentaorganizujacego")]
        public int OrganizerId { get; set; }
        [Column("idpoprawianegokursu")]
        public int CourseId { get; set; }
        [Column("idproponowanegozamiennegokursu")]
        public int? ProposedOtherCourseId { get; set; }
        [Column("status")]
        public ApplicationState State { get; set; }
        [Column("sala")]
        public string Classroom { get; set; }
        [Column("godzinarozpoczecia")]
        public TimeSpan StartTime { get; set; }
        [Column("godzinazakonczenia")]
        public TimeSpan EndTime { get; set; }
        [Column("tydzien")]
        public WeekType Week { get; set; }
        [Column("dzien")]
        public DayOfWeek Day { get; set; }
        [Column("rodzajpodania")]
        public string ApplicationType { get; set; }

        public ICollection<TeacherConfirmation> TeacherConfirmations { get; set; }
        public User Organizer { get; set; }
        public Course Course { get; set; }
    }
}