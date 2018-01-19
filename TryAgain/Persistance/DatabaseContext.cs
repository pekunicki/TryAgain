using Microsoft.EntityFrameworkCore;
using TryAgain.Persistance.Entity;

namespace TryAgain.Persistance
{
    internal class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .ToTable("kurs");

            modelBuilder.Entity<User>()
                .ToTable("uzytkownik");

//            modelBuilder.HasSequence<int>("podanieokurspoprawkowy", schema: "public")
//                .StartsAt(10)
//                .IncrementsBy(1);
//
//            modelBuilder.Entity<Application>()
//                .Property(app => app.Id)
//                .HasDefaultValueSql("NEXT VALUE FOR public.podanieokurspoprawkowy");

            modelBuilder.Entity<Application>()
                .ToTable("podanieokurspoprawkowy")
                .HasOne(app => app.Organizer)
                .WithMany(u => u.Applications)
                .HasForeignKey(app => app.OrganizerId);

            modelBuilder.Entity<Application>()
                .HasOne(app => app.Course)
                .WithMany(c => c.Applications)
                .HasForeignKey(app => app.CourseId);

            modelBuilder.Entity<Teacher>()
                .ToTable("prowadzacy");

            modelBuilder.Entity<TeacherConfirmation>()
                .ToTable("potwierdzenieprowadzacego")
                .HasOne<Teacher>(tc => tc.Teacher)
                .WithMany(t => t.TeacherConfirmations)
                .HasForeignKey(tc => tc.TeacherId);

            modelBuilder.Entity<TeacherConfirmation>()
                .HasOne<Application>(tc => tc.Application)
                .WithMany(t => t.TeacherConfirmations)
                .HasForeignKey(tc => tc.ApplicationId);
        }

        public DbSet<Application> Applications { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<TeacherConfirmation> TeacherConfirmations { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
