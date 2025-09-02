namespace PruebaTecnicaCamiloCadavid.App.Dtos
{
    public record PersonDto(
        int Id,
        string FirstName,
        string LastName,
        string DocumentType,
        string Document,
        string Email,
        int Age,
        DateOnly BirthDate,
        string Genero,
        string PhoneNumber,
        List<RoleDto> Roles,
        List<AddressConcatenateDto> Addresses
    );
}
