using MediatR;

namespace PruebaTecnicaCamiloCadavid.App.PersonUseCases.Delete
{
    public record DeletePersonCommand(int Id):IRequest;
}
