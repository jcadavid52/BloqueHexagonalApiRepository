using PruebaTecnicaCamiloCadavid.App.Dtos;
using PruebaTecnicaCamiloCadavid.Domain.Models;

namespace PruebaTecnicaCamiloCadavid.App.Extensions
{
    public static class AddressExtensions
    {
        public static List<AddressDto> ToAddressListDto(this List<Address> addresses)
        {
            return addresses
                .Select(a => new AddressDto(
                  a.Street,
                  a.City,
                  a.Country,
                  a.PostalCode,
                  a.IdPerson
                )).ToList();
        }
    }
}
