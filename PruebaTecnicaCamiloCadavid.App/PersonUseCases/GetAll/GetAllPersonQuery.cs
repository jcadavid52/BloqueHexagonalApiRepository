using MediatR;

namespace PruebaTecnicaCamiloCadavid.App.PersonUseCases.GetAll
{
    public record GetAllPersonQuery():IRequest<GetAllPersonResponse>;
}
