using MediatR;

namespace PruebaTecnicaCamiloCadavid.App.AddressUseCases.Create
{
    public record CreateAddressCommand(
        string Street,
        string City,
        string Country,
        string? PostalCode,
        int IdPerson
        ) :IRequest<Guid>;
}
