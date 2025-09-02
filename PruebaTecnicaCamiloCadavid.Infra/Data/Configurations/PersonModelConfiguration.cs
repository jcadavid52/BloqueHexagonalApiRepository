using Microsoft.EntityFrameworkCore;
using PruebaTecnicaCamiloCadavid.Domain.Models;

namespace PruebaTecnicaCamiloCadavid.Infra.Data.Configurations
{
    public class PersonModelConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Personas");

            builder.HasKey(person => person.Id);

            builder.Property(person => person.Id)
                .HasColumnName("IdPersona")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(person => person.FirstName)
                .HasColumnName("Nombres")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(person => person.LastName)
                .HasColumnName("Apellidos")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(person => person.Document)
                .HasColumnName("Documento")
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(person => person.Email)
                .HasColumnName("CorreoElectronico")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(person => person.Age)
                .HasColumnName("Edad")
                .IsRequired();

            builder.Property(person => person.BirthDate)
                .HasColumnName("FechaNacimiento")
                .IsRequired();

            builder.Property(person => person.Genero)
                .HasColumnName("Genero")
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(person => person.PhoneNumber)
                .HasColumnName("NumeroTelefono")
                .IsRequired()
                .HasMaxLength(15);

            builder.OwnsOne(person => person.DocumentType, documentType =>
            {
                documentType.Property(documenttype => documenttype.Value)
                    .HasColumnName("TipoDocumento")
                    .IsRequired()
                    .HasMaxLength(3);
            });

            builder.HasMany(person => person.RolePerson)
                .WithOne(rolePerson => rolePerson.Person)
                .HasForeignKey(rolePerson => rolePerson.IdPerson)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
