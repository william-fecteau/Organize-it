using mchacks2022.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace mchacks2022.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public DbSet<Class> Classes{ get; set; }
        public DbSet<Deadline> Deadlines { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<SemesterClass> SemesterClass { get; set; }
        public DbSet<SemesterClassSchedule> SemesterClassSchedule { get; set; }
        public DbSet<SemesterClassNotes> SemesterClassNotes { get; set; }
        public DbSet<Note> Notes { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SemesterClass>().HasKey(p => new { p.FkSemesterId, p.FkClassId});
        }
    }
}
