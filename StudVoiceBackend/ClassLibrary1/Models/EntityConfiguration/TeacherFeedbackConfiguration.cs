using System;
using System.Collections.Generic;
using System.Text;
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
                .IsRequired()
                .HasMaxLength(1);

            builder.Property(e => e.TeacherId).HasColumnName("TeacherID");

            builder.HasOne(d => d.Teacher)
                .WithMany(p => p.TeacherFeedbacks)
                .HasForeignKey(d => d.TeacherId)
                .HasConstraintName("FK__TeacherFe__Teach__3C69FB99");
        }
    }
}
