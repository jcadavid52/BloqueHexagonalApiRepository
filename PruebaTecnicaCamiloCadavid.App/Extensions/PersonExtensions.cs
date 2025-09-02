using PruebaTecnicaCamiloCadavid.App.Dtos;
using PruebaTecnicaCamiloCadavid.Domain.Models;

namespace PruebaTecnicaCamiloCadavid.App.Extensions
{
    public static class PersonExtensions
    {
        public static List<PersonDto> ToPersonDtoList(this List<Person> people)
        {
            return people.Select(p => new PersonDto(
                p.Id,
                p.FirstName,
                p.LastName,
                p.DocumentType.Value,
                p.Document,
                p.Email,
                p.Age,
                p.BirthDate,
                p.Genero,
                p.PhoneNumber,
                p.RolePerson.Select(rp => new RoleDto(
                    rp.Role.Id,
                    rp.Role.Name
                    )).ToList(),
                p.Addresses.Select(a => new AddressConcatenateDto(
                    a.Country + ", " + a.City + ", " + a.Street
                    )).ToList()
                )).ToList();
        }

        public static PersonDto ToPersonDto(this Person person)
        {
            return new PersonDto(
                person.Id,
                person.FirstName,
                person.LastName,
                person.DocumentType.Value,
                person.Document,
                person.Email,
                person.Age,
                person.BirthDate,
                person.Genero,
                person.PhoneNumber,
                person.RolePerson.Select(rp => new RoleDto(
                  rp.Role.Id,
                  rp.Role.Name
                )).ToList(),
                person.Addresses.Select(a => new AddressConcatenateDto(
                      a.Country + ", " + a.City + ", " + a.Street

                )).ToList()
            );
        }
    }
}
