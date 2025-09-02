using MediatR;
using PruebaTecnicaCamiloCadavid.App.Extensions;
using PruebaTecnicaCamiloCadavid.Domain.Ports;

namespace PruebaTecnicaCamiloCadavid.App.RoleUseCases.GetAll
{
    public class GetAllRoleQueryHandler(IRoleRepository roleRepository) : IRequestHandler<GetAllRoleQuery, GetAllRoleQueryResponse>
    {
        public async Task<GetAllRoleQueryResponse> Handle(GetAllRoleQuery request, CancellationToken cancellationToken)
        {
            var roles = await roleRepository.GetAllAsync();

            var rolesDtos = RoleExtensions.ToRoleListDto(roles);
                
            return new GetAllRoleQueryResponse(rolesDtos);
        }
    }
}
