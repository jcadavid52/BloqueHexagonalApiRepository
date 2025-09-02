using MediatR;

namespace PruebaTecnicaCamiloCadavid.App.AddressUseCases.GetAll
{
    public record GetAllRoleQuery():IRequest<GetAllRoleQueryResponse>;
}
