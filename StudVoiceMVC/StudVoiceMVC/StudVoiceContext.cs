using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace StudVoiceMVC
{
    public partial class StudVoiceContext : DbContext
    {
        public StudVoiceContext()
        {
        }

        public StudVoiceContext(DbContextOptions<StudVoiceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Contacts> Contacts { get; set; }
        public virtual DbSet<Faculties> Faculties { get; set; }
        public virtual DbSet<LessonFeedbacks> LessonFeedbacks { get; set; }
        public virtual DbSet<Lessons> Lessons { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<TeacherFeedbacks> TeacherFeedbacks { get; set; }
        public virtual DbSet<Teachers> Teachers { get; set; }
        public virtual DbSet<UserRoles> UserRoles { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=StudVoice;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Contacts>(entity =>
            {
                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Contacts__A9D10534C6B55886")
                    .IsUnique();

                entity.HasIndex(e => e.Phone)
                    .HasName("UQ__Contacts__5C7E359E696A5168")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(4000);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(4000);
            });

            modelBuilder.Entity<Faculties>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("UQ__Facultie__737584F6558150FA")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(4000);
            });

            modelBuilder.Entity<LessonFeedbacks>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Feedback)
                    .IsRequired()
                    .HasMaxLength(4000);

                entity.Property(e => e.LessonId).HasColumnName("LessonID");

                entity.HasOne(d => d.Lesson)
                    .WithMany(p => p.LessonFeedbacks)
                    .HasForeignKey(d => d.LessonId)
                    .HasConstraintName("FK__LessonFee__Lesso__628FA481");
            });

            modelBuilder.Entity<Lessons>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(4000);

                entity.Property(e => e.TeacherId).HasColumnName("TeacherID");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Lessons)
                    .HasForeignKey(d => d.TeacherId)
                    .HasConstraintName("FK__Lessons__Teacher__5FB337D6");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("UQ__Roles__737584F6E27B3C27")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(4000)
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(4000);
            });

            modelBuilder.Entity<TeacherFeedbacks>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Feedback)
                    .IsRequired()
                    .HasMaxLength(4000);

                entity.Property(e => e.TeacherId).HasColumnName("TeacherID");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.TeacherFeedbacks)
                    .HasForeignKey(d => d.TeacherId)
                    .HasConstraintName("FK__TeacherFe__Teach__656C112C");
            });

            modelBuilder.Entity<Teachers>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(4000);

                entity.Property(e => e.UserId).HasMaxLength(4000);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Teachers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Teachers__UserId__5CD6CB2B");
            });

            modelBuilder.Entity<UserRoles>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(4000)
                    .ValueGeneratedNever();

                entity.Property(e => e.RoleId).HasMaxLength(4000);

                entity.Property(e => e.UserId).HasMaxLength(4000);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__UserRoles__RoleI__59FA5E80");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__UserRoles__UserI__59063A47");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(4000)
                    .ValueGeneratedNever();

                entity.Property(e => e.MiddleName).HasMaxLength(4000);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(4000);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(4000);

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.ContactId)
                    .HasConstraintName("FK__Users__ContactId__52593CB8");

                entity.HasOne(d => d.Faculty)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.FacultyId)
                    .HasConstraintName("FK__Users__FacultyId__534D60F1");
            });
        }
    }
}
