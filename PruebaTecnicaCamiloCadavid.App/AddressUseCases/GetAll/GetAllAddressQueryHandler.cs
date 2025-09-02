using MediatR;
using PruebaTecnicaCamiloCadavid.App.Extensions;
using PruebaTecnicaCamiloCadavid.Domain.Ports;

namespace PruebaTecnicaCamiloCadavid.App.AddressUseCases.GetAll
{
    public class GetAllRoleQueryHandler(IAddressRepository addressRepository) : IRequestHandler<GetAllRoleQuery, GetAllRoleQueryResponse>
    {
        public async Task<GetAllRoleQueryResponse> Handle(GetAllRoleQuery request, CancellationToken cancellationToken)
        {
            var addresses = await addressRepository.GetAllAsync();

            var addressesDtos = AddressExtensions.ToAddressListDto(addresses);
                
            return new GetAllRoleQueryResponse(addressesDtos);
        }
    }
}
