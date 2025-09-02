using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PruebaTecnicaCamiloCadavid.Domain.Models;

namespace PruebaTecnicaCamiloCadavid.Infra.Data.Configurations
{
    public class RoleModelConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles");

            builder.HasKey(role => role.Id);

            builder.Property(role => role.Id)
                .HasColumnName("IdRol")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(role => role.Name)
                .HasColumnName("Nombre")
                .IsRequired()
                .HasMaxLength(50);

            builder.HasMany(role => role.RolePerson)
                .WithOne(rolePerson => rolePerson.Role)
                .HasForeignKey(rolePerson => rolePerson.IdRole)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
