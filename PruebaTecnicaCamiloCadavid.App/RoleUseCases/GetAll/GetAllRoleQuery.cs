using MediatR;

namespace PruebaTecnicaCamiloCadavid.App.RoleUseCases.GetAll
{
    public record GetAllRoleQuery():IRequest<GetAllRoleQueryResponse>;
}
