namespace PruebaTecnicaCamiloCadavid.App.Dtos
{
    public record AddressDto(
        string Street,
        string City,
        string Country,
        string? PostalCode,
        int IdPerson
    );
}
