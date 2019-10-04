﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace StudVoice.DAL.Models.EntityConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(e => e.Id)
                .HasColumnName("ID")
                .HasMaxLength(1)
                .ValueGeneratedNever();

            builder.Property(e => e.MiddleName).HasMaxLength(1);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(1);

            builder.Property(e => e.Surname)
                .IsRequired()
                .HasMaxLength(1);

            builder.HasOne(d => d.Contact)
                .WithMany(p => p.Users)
                .HasForeignKey(d => d.ContactId)
                .HasConstraintName("FK__Users__ContactId__2A4B4B5E");

            builder.HasOne(d => d.Faculty)
                .WithMany(p => p.Users)
                .HasForeignKey(d => d.FacultyId)
                .HasConstraintName("FK__Users__FacultyId__2B3F6F97");
        }
    }
}