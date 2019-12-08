using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace StudVoice.DAL.Models.EntityConfiguration
{
    public class TeacherFeedbackConfiguration : IEntityTypeConfiguration<TeacherFeedback>
    {
        public void Configure(EntityTypeBuilder<TeacherFeedback> builder)
        {
            builder.ToTable("TeacherFeedbacks");

            builder.Property(e => e.Id)
                .HasColumnName("ID")
                .ValueGeneratedNever();

            builder.Property(e => e.Feedback)
                .IsRequired();

            builder.Property(e => e.TeacherId).HasColumnName("TeacherID");

            builder.HasOne(d => d.Teacher)
                .WithMany(p => p.TeacherFeedbacks)
                .HasForeignKey(d => d.TeacherId)
                .HasConstraintName("FK__TeacherFe__Teach__3C69FB99");

            builder.HasOne(u => u.Create)
                .WithMany(u => u.TeacherFeedbackCreate)
                .HasForeignKey(u => u.CreatedById);

            builder.HasOne(u => u.Mod)
                .WithMany(u => u.TeacherFeedbackMod)
                .HasForeignKey(u => u.UpdatedById);
        }
    }
}
