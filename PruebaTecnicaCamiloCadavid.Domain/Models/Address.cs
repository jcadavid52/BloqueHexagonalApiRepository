using PruebaTecnicaCamiloCadavid.Domain.Abstractions;

namespace PruebaTecnicaCamiloCadavid.Domain.Models
{
    public class Address: DomainEntity<Guid>
    {
        public string Street { get; private set; } = default!;
        public string City { get; private set; } = default!;
        public string Country { get; private set; } = default!;
        public string? PostalCode { get; private set; }
        public int IdPerson { get; set; }
        public Person Person { get; set; } = default!;

        public static Address Create(
            string street,
            int idPerson,
            string city,
            string country,
            string? postalCode = null)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(street, nameof(street));
            ArgumentNullException.ThrowIfNullOrEmpty(country, nameof(country));
            ArgumentNullException.ThrowIfNullOrEmpty(city, nameof(city));

            if ( idPerson == default || idPerson <= 0)
                throw new ArgumentException("El id pesona no es válido");

            return new Address
            {
                Id = Guid.NewGuid(),
                Street = street,
                City = city,
                Country = country,
                PostalCode = postalCode,
                IdPerson = idPerson
            };
        }
    }
}
