using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace StudVoice.DAL.Models.EntityConfiguration
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.ToTable("Teachers");

            builder.Property(e => e.Id)
                .HasColumnName("ID")
                .ValueGeneratedNever();

            builder.Property(e => e.Name)
                .IsRequired();


            builder.HasOne(d => d.User)
                .WithMany(p => p.Teachers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Teachers__UserId__33D4B598");

            builder.HasOne(u => u.Create)
                .WithMany(u => u.TeacherCreate)
                .HasForeignKey(u => u.CreatedById);

            builder.HasOne(u => u.Mod)
                .WithMany(u => u.TeacherMod)
                .HasForeignKey(u => u.UpdatedById);
        }
    }
}
