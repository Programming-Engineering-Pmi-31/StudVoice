using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace StudVoice.DAL.Models.EntityConfiguration
{
    public class LessonFeedbackConfiguration : IEntityTypeConfiguration<LessonFeedback>
    {
        public void Configure(EntityTypeBuilder<LessonFeedback> builder)
        {
            builder.ToTable("LessonFeedbacks");

            builder.Property(e => e.Id)
                .HasColumnName("ID")
                .ValueGeneratedNever();

            builder.Property(e => e.Feedback)
                .IsRequired();

            builder.Property(e => e.LessonId).HasColumnName("LessonID");

            builder.HasOne(d => d.Lesson)
                .WithMany(p => p.LessonFeedbacks)
                .HasForeignKey(d => d.LessonId)
                .HasConstraintName("FK__LessonFee__Lesso__398D8EEE");

            builder.HasOne(u => u.Create)
                .WithMany(u => u.LessonFeedbackCreate)
                .HasForeignKey(u => u.CreatedById);

            builder.HasOne(u => u.Mod)
                .WithMany(u => u.LessonFeedbackMod)
                .HasForeignKey(u => u.UpdatedById);
        }
    }
}
