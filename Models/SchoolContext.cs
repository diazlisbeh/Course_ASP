using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ASP.NET.Models
{
    public partial class SchoolContext : DbContext
    {
        public SchoolContext()
        {
        }

        public SchoolContext(DbContextOptions<SchoolContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<Exam> Exams { get; set; } = null!;
        public virtual DbSet<School> Schools { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<StudentsXExam> StudentsXExams { get; set; } = null!;
        public virtual DbSet<Subject> Subjects { get; set; } = null!;
        public virtual DbSet<Tandum> Tanda { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_unicode_ci")
                .HasCharSet("utf8mb4");

             var escuela = new School();
            
            escuela.Id = 34;
            escuela.Name = "Platzi School";
            escuela.City = "Bogota";
            escuela.Country = "Colombia";
            
            

            modelBuilder.Entity<School>().HasData(escuela);
            
            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.IdCourse)
                    .HasName("PRIMARY");

                entity.ToTable("course");

                entity.HasIndex(e => e.IdTanda, "id_tanda");

                entity.Property(e => e.IdCourse)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_course");

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .HasColumnName("code");

                entity.Property(e => e.IdTanda)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_tanda");

                entity.Property(e => e.Name)
                    .HasMaxLength(60)
                    .HasColumnName("name");

                entity.HasOne(d => d.IdTandaNavigation)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.IdTanda)
                    .HasConstraintName("course_ibfk_1");
            });

            modelBuilder.Entity<Exam>(entity =>
            {
                entity.HasKey(e => e.IdExam)
                    .HasName("PRIMARY");

                entity.ToTable("exam");

                entity.HasIndex(e => e.IdSubject, "id_subject");

                entity.Property(e => e.IdExam)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_exam");

                entity.Property(e => e.IdSubject)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_subject");

                entity.Property(e => e.Tittle)
                    .HasMaxLength(20)
                    .HasColumnName("tittle");

                entity.Property(e => e.Value)
                    .HasColumnType("int(11)")
                    .HasColumnName("value");

                entity.HasOne(d => d.IdSubjectNavigation)
                    .WithMany(p => p.Exams)
                    .HasForeignKey(d => d.IdSubject)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("exam_ibfk_1");
            });

            modelBuilder.Entity<School>(entity =>
            {
                entity.ToTable("school");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.AnioCreacion).HasColumnName("anio_creacion");

                entity.Property(e => e.City)
                    .HasMaxLength(60)
                    .HasColumnName("city");

                entity.Property(e => e.Country)
                    .HasMaxLength(20)
                    .HasColumnName("country");

                entity.Property(e => e.Name)
                    .HasMaxLength(80)
                    .HasColumnName("name");
                entity.Property(e => e.TypeSchool);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.IdStudent)
                    .HasName("PRIMARY");

                entity.ToTable("student");

                entity.HasIndex(e => e.IdSchool, "id_school");

                entity.Property(e => e.IdStudent)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_student");

                entity.Property(e => e.Age)
                    .HasColumnType("int(11)")
                    .HasColumnName("age");

                entity.Property(e => e.IdSchool)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_school");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .HasColumnName("last_name");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .HasColumnName("name");

                entity.HasOne(d => d.IdSchoolNavigation)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.IdSchool)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("student_ibfk_1");
            });

            modelBuilder.Entity<StudentsXExam>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("students_x_exams");

                entity.HasIndex(e => e.IdExam, "id_exam");

                entity.HasIndex(e => e.IdStudent, "id_student");

                entity.Property(e => e.IdExam)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_exam");

                entity.Property(e => e.IdStudent)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_student");

                entity.HasOne(d => d.IdExamNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdExam)
                    .HasConstraintName("students_x_exams_ibfk_1");

                entity.HasOne(d => d.IdStudentNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdStudent)
                    .HasConstraintName("students_x_exams_ibfk_2");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.HasKey(e => e.IdSubject)
                    .HasName("PRIMARY");

                entity.ToTable("subject");

                entity.HasIndex(e => e.IdCourse, "id_course");

                entity.Property(e => e.IdSubject)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_subject");

                entity.Property(e => e.Calification)
                    .HasColumnType("int(11)")
                    .HasColumnName("calification");

                entity.Property(e => e.IdCourse)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_course");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .HasColumnName("name");

                entity.HasOne(d => d.IdCourseNavigation)
                    .WithMany(p => p.Subjects)
                    .HasForeignKey(d => d.IdCourse)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("subject_ibfk_1");
            });

            modelBuilder.Entity<Tandum>(entity =>
            {
                entity.HasKey(e => e.IdTanda)
                    .HasName("PRIMARY");

                entity.ToTable("tanda");

                entity.Property(e => e.IdTanda)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_tanda");

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
