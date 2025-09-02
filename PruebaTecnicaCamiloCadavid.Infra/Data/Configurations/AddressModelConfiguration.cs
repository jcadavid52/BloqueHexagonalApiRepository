using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PruebaTecnicaCamiloCadavid.Domain.Models;

namespace PruebaTecnicaCamiloCadavid.Infra.Data.Configurations
{
    public class AddressModelConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Direcciones");

            builder.HasKey(address => address.Id);

            builder.Property(address => address.Id)
                .HasColumnName("IdDireccion")
                .IsRequired();

            builder.Property(address => address.Street)
                .HasColumnName("Calle")
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(address => address.City)
                .HasColumnName("Ciudad")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(address => address.Country)
                .HasColumnName("Pais")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(address => address.PostalCode)
                .HasColumnName("CodigoPostal")
                .HasMaxLength(20);

            builder.Property(address => address.CreatedAt)
                .HasColumnName("FechaCreacion")
                .IsRequired();

            builder.HasOne(address => address.Person)
                .WithMany(person => person.Addresses)
                .HasForeignKey(address => address.IdPerson)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
