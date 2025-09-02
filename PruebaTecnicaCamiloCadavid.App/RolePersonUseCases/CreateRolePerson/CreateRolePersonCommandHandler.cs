using MediatR;
using PruebaTecnicaCamiloCadavid.Domain.Models;
using PruebaTecnicaCamiloCadavid.Domain.Ports;

namespace PruebaTecnicaCamiloCadavid.App.RolePersonUseCases.CreateRolePerson
{
    public class CreateRolePersonCommandHandler (
        IRolePersonRepository rolePersonRepository,
        IUnitOfWork unitOfWork
        ): IRequestHandler<CreateRolePersonCommand>
    {
        public async Task Handle(CreateRolePersonCommand request, CancellationToken cancellationToken)
        {
            var rolePerson = RolePerson.Create(request.IdRole,request.IdPerson);

            await rolePersonRepository.Add(rolePerson);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
