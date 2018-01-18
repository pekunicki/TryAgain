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
                .ToTable("podanieokurspoprawkowy");

            modelBuilder.Entity<Teacher>()
                .ToTable("prowadzacy");

            modelBuilder.Entity<TeacherConfirmation>()
                .ToTable("potwierdzenieprowadzacego");

        }

        public DbSet<Application> Applications { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<TeacherConfirmation> TeacherConfirmations { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
