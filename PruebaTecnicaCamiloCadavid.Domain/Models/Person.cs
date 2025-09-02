using PruebaTecnicaCamiloCadavid.Domain.Abstractions;
using PruebaTecnicaCamiloCadavid.Domain.ValueObjects;

namespace PruebaTecnicaCamiloCadavid.Domain.Models
{
    public class Person:DomainEntity<int>
    {
        public string FirstName { get; private set; } = default!;
        public string LastName { get; private set; } = default!;
        public DocumentType DocumentType { get; set; } = default!;
        public string Document { get; private set; } = default!;
        public string Email { get; private set; } = default!;
        public int Age { get; private set; }
        public DateOnly BirthDate { get; private set; }
        public string Genero { get; private set; } = default!;
        public string PhoneNumber { get; private set; } = default!;

        public ICollection<RolePerson> RolePerson { get; set; } = new List<RolePerson>();
        public ICollection<Address> Addresses { get; set; } = new List<Address>();

        public static Person Create(
            string firstName,
            string lastName,
            DocumentType documentType,
            string document,
            string email,
            DateOnly birthDate,
            string genero,
            string phoneNumber
            )
        {
            ArgumentNullException.ThrowIfNullOrEmpty(firstName, nameof(firstName));
            ArgumentNullException.ThrowIfNullOrEmpty(lastName, nameof(lastName));
            ArgumentNullException.ThrowIfNullOrEmpty(documentType.Value, nameof(documentType));
            ArgumentNullException.ThrowIfNullOrEmpty(document, nameof(document));
            ArgumentNullException.ThrowIfNullOrEmpty(email, nameof(email));
            ArgumentNullException.ThrowIfNullOrEmpty(genero, nameof(genero));
            ArgumentNullException.ThrowIfNullOrEmpty(phoneNumber, nameof(phoneNumber));

            if(birthDate == default)
                throw new ArgumentNullException(nameof(birthDate));

            return new Person
            {
                FirstName = firstName,
                LastName = lastName,
                DocumentType = documentType,
                Document = document,
                Email = email,
                Age = GetAge(birthDate),
                BirthDate = birthDate,
                Genero = genero,
                PhoneNumber = phoneNumber
            };
        }

        public void Update(
           int id,
           string firstName,
           string lastName,
           DocumentType documentType,
           string document,
           string email,
           DateOnly birthDate,
           string genero,
           string phoneNumber
           )
        {
            ArgumentNullException.ThrowIfNullOrEmpty(firstName, nameof(firstName));
            ArgumentNullException.ThrowIfNullOrEmpty(lastName, nameof(lastName));
            ArgumentNullException.ThrowIfNullOrEmpty(documentType.Value, nameof(documentType));
            ArgumentNullException.ThrowIfNullOrEmpty(document, nameof(document));
            ArgumentNullException.ThrowIfNullOrEmpty(email, nameof(email));
            ArgumentNullException.ThrowIfNullOrEmpty(genero, nameof(genero));
            ArgumentNullException.ThrowIfNullOrEmpty(phoneNumber, nameof(phoneNumber));

            if (birthDate == default)
                throw new ArgumentNullException(nameof(birthDate));

            if (id == default || id <= 0)
                throw new ArgumentException("El id pesona no es válido");

            FirstName = firstName;
            LastName = lastName;
            DocumentType = documentType;
            Document = document;
            Email = email;
            BirthDate = birthDate;
            Age = GetAge(birthDate);
            Genero = genero;
            PhoneNumber = phoneNumber;
        }

        private static int GetAge(DateOnly birthDate)
        {
            var today = DateOnly.FromDateTime(DateTime.UtcNow);
            int age = today.Year - birthDate.Year;
            if (today < birthDate.AddYears(age))
                age--;

            return age;
        }
    }
}
