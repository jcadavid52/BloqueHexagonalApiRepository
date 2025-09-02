using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PruebaTecnicaCamiloCadavid.Domain.Models;

namespace PruebaTecnicaCamiloCadavid.Infra.Data.Configurations
{
    public class RolePersonModelConfiguration:IEntityTypeConfiguration<RolePerson>
    {
        public void Configure(EntityTypeBuilder<RolePerson> builder)
        {
            builder.ToTable("RolePerson");

            builder.HasKey(rolePerson => new { rolePerson.IdPerson, rolePerson.IdRole });

            builder.HasOne(rolePerson => rolePerson.Person)
                .WithMany(p => p.RolePerson)
                .HasForeignKey(rolePerson => rolePerson.IdPerson)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(rolePerson => rolePerson.Role)
                .WithMany(r => r.RolePerson)
                .HasForeignKey(rolePerson => rolePerson.IdRole)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
