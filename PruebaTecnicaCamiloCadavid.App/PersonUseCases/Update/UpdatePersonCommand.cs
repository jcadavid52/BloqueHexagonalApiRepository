using MediatR;
using System.Text.Json.Serialization;

namespace PruebaTecnicaCamiloCadavid.App.PersonUseCases.Update
{
    public record UpdatePersonCommand(
        string? FirstName,
        string? LastName,
        string? DocumentType,
        string? Document,
        string? Email,
        DateOnly? BirthDate,
        string? Genero,
        string? PhoneNumber
        ) : IRequest<UpdatePersonCommandResponse>
    {
        [JsonIgnore]
        public int Id { get; init; }
    }
}
