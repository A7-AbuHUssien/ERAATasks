using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Models;

namespace P01_StudentSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        // DbSets
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                  optionsBuilder.UseSqlServer(
                        "Server = localhost; Database = P01_StudentSystem; User ID=sa; Password=DB_Password; TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Student
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(s => s.StudentId);

                entity.Property(s => s.Name)
                      .HasMaxLength(100)
                      .IsUnicode(true)
                      .IsRequired();

                entity.Property(s => s.PhoneNumber)
                      .HasMaxLength(10)
                      .IsUnicode(false)
                      .IsRequired(false);

                entity.Property(s => s.RegisteredOn)
                      .IsRequired();

                entity.Property(s => s.Birthday)
                      .IsRequired(false);
            });

            // Course
            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(c => c.CourseId);

                entity.Property(c => c.Name)
                      .HasMaxLength(80)
                      .IsUnicode(true)
                      .IsRequired();

                entity.Property(c => c.Description)
                      .IsUnicode(true)
                      .IsRequired(false);

                entity.Property(c => c.StartDate)
                      .IsRequired();

                entity.Property(c => c.EndDate)
                      .IsRequired();

                entity.Property(c => c.Price)
                      .IsRequired();
            });

            // Resource
            modelBuilder.Entity<Resource>(entity =>
            {
                entity.HasKey(r => r.ResourceId);

                entity.Property(r => r.Name)
                      .HasMaxLength(50)
                      .IsUnicode(true)
                      .IsRequired();

                entity.Property(r => r.Url)
                      .IsUnicode(false)
                      .IsRequired();

                entity.Property(r => r.ResourceType)
                      .IsRequired();

                entity.HasOne(r => r.Course)
                      .WithMany(c => c.Resources)
                      .HasForeignKey(r => r.CourseId);
            });

            // Homework
            modelBuilder.Entity<Homework>(entity =>
            {
                entity.HasKey(h => h.HomeworkId);

                entity.Property(h => h.Content)
                      .IsUnicode(false)
                      .IsRequired();

                entity.Property(h => h.ContentType)
                      .IsRequired();

                entity.Property(h => h.SubmissionTime)
                      .IsRequired();

                entity.HasOne(h => h.Student)
                      .WithMany(s => s.HomeworkSubmissions)
                      .HasForeignKey(h => h.StudentId);

                entity.HasOne(h => h.Course)
                      .WithMany(c => c.HomeworkSubmissions)
                      .HasForeignKey(h => h.CourseId);
            });

            // StudentCourse (Mapping Table)
            modelBuilder.Entity<StudentCourse>(entity =>
            {
                entity.HasKey(sc => new { sc.StudentId, sc.CourseId });

                entity.HasOne(sc => sc.Student)
                      .WithMany(s => s.CourseEnrollments)
                      .HasForeignKey(sc => sc.StudentId);

                entity.HasOne(sc => sc.Course)
                      .WithMany(c => c.StudentsEnrolled)
                      .HasForeignKey(sc => sc.CourseId);
            });
        }
    }
}