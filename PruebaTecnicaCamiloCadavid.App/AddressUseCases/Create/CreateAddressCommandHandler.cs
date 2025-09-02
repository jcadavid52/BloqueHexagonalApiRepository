using MediatR;
using PruebaTecnicaCamiloCadavid.App.AddressUseCases.Create;
using PruebaTecnicaCamiloCadavid.Domain.Models;
using PruebaTecnicaCamiloCadavid.Domain.Ports;

namespace PruebaTecnicaCamiloCadavid.App.AddressUseCases.Add
{
    public class CreateAddressCommandHandler(
        IAddressRepository addressRepository,
        IUnitOfWork unitOfWork
        ) : IRequestHandler<CreateAddressCommand, Guid>
    {
        public async Task<Guid> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            var address = Address.Create(
                request.Street.Trim(),
                request.IdPerson,
                request.City.Trim(),
                request.Country.Trim(),
                request.PostalCode?.Trim()
            );

            await addressRepository.Add(address);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return address.Id;
        }
    }
}
