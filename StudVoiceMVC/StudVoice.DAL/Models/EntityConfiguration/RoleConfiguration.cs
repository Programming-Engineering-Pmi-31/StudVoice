using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace StudVoice.DAL.Models.EntityConfiguration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasIndex(e => e.Name)
                .HasName("UQ__Roles__737584F6E20101C3")
                .IsUnique();

            builder.Property(e => e.Id)
                .HasColumnName("ID")
                .ValueGeneratedNever();

            builder.Property(e => e.Name)
                .IsRequired();
        }
    }
}
