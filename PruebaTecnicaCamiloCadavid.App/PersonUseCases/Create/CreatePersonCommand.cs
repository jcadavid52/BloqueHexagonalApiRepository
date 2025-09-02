using MediatR;

namespace PruebaTecnicaCamiloCadavid.App.PersonUseCases.Create
{
    public record CreatePersonCommand(
        string FirstName,
        string LastName,
        string DocumentType,
        string Document,
        string Email,
        DateOnly BirthDate,
        string Genero,
        string PhoneNumber
        ) :IRequest<int>;
}
