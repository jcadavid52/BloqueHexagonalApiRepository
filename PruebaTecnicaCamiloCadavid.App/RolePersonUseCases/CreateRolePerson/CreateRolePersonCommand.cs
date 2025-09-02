using MediatR;

namespace PruebaTecnicaCamiloCadavid.App.RolePersonUseCases.CreateRolePerson
{
    public record CreateRolePersonCommand(int IdRole,int IdPerson):IRequest;
}
