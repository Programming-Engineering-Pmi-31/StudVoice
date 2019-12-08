using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using StudVoice.DAL.Models.Entities.Abstractions;
using StudVoice.DAL.Models.EntityConfiguration;

namespace StudVoice.DAL
{
    public  class StudVoiceDBContext : IdentityDbContext<User, Role, string, IdentityUserClaim<string>,
        UserRole, IdentityUserLogin<string>,
        IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        private string _currentUserId;


        public StudVoiceDBContext(DbContextOptions<StudVoiceDBContext> options)
            : base(options)
        {
        }
        public StudVoiceDBContext() { }

        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Faculty> Faculties { get; set; }
        public virtual DbSet<LessonFeedback> LessonFeedbacks { get; set; }
        public virtual DbSet<Lesson> Lessons { get; set; }
        public virtual DbSet<TeacherFeedback> TeacherFeedbacks { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }

        public string CurrentUserId
        {
            get => _currentUserId;
            set
            {
                if (_currentUserId != value)
                {
                    _currentUserId = value;
                }
            }
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            if (CurrentUserId != null)
            {
                IEnumerable<EntityEntry> unsavedItems = ChangeTracker.Entries()
                    .Where(entity => entity.Entity is IAuditableEntity &&
                                     (entity.State == EntityState.Added ||
                                      entity.State == EntityState.Modified));

                foreach (EntityEntry item in unsavedItems)
                {
                    IAuditableEntity entity = (IAuditableEntity)item.Entity;
                    DateTime now = DateTime.Now;
                    if (item.State == EntityState.Added)
                    {
                        entity.CreatedById = CurrentUserId;
                    }
                    entity.UpdatedById = CurrentUserId;
                    entity.UpdatedDate = now;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            #region Configuration
            modelBuilder.ApplyConfiguration(new ContactConfiguration());
            modelBuilder.ApplyConfiguration(new FacultyConfiguration());
            modelBuilder.ApplyConfiguration(new LessonConfiguration());
            modelBuilder.ApplyConfiguration(new LessonConfiguration());
            modelBuilder.ApplyConfiguration(new LessonFeedbackConfiguration());
            modelBuilder.ApplyConfiguration(new TeacherConfiguration());
            modelBuilder.ApplyConfiguration(new TeacherFeedbackConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
            #endregion
        }
    }
}
