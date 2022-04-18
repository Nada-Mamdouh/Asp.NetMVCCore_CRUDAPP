using ConnectingToDB_Lab3.Models;
using Microsoft.EntityFrameworkCore;
namespace ConnectingToDB_Lab3.Data
{
    public class ITIDBContext:DbContext
    {
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<StudentCourses> StudentCourses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;DataBase=ITIMansoura;Trusted_Connection=True");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().HasKey(c => c.CrsId);
            modelBuilder.Entity<Course>().Property(c => c.CrsName).IsRequired();
            modelBuilder.Entity<StudentCourses>()
                .HasKey(a => new{
                a.StudentId,
                a.CrsId});
            base.OnModelCreating(modelBuilder);
        }
    }
}
