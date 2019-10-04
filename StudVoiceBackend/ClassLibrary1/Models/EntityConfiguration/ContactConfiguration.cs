using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StudVoice.DAL.Models.EntityConfiguration
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("Contacts");

            builder.HasIndex(e => e.Email)
                .HasName("UQ__Contacts__A9D10534674F8231")
                .IsUnique();

            builder.HasIndex(e => e.Phone)
                .HasName("UQ__Contacts__5C7E359E834222FA")
                .IsUnique();

            builder.Property(e => e.Id)
                .HasColumnName("ID")
                .ValueGeneratedNever();

            builder.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(1);

            builder.Property(e => e.Phone)
                .IsRequired()
                .HasMaxLength(1);
        }
    }
}
