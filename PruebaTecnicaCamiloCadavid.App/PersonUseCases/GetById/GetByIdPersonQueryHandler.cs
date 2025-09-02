using MediatR;
using PruebaTecnicaCamiloCadavid.App.Dtos;
using PruebaTecnicaCamiloCadavid.App.Exceptions;
using PruebaTecnicaCamiloCadavid.App.Extensions;
using PruebaTecnicaCamiloCadavid.Domain.Ports;

namespace PruebaTecnicaCamiloCadavid.App.PersonUseCases.GetById
{
    public class GetByIdPersonQueryHandler(IPersonRepository personRepository) : IRequestHandler<GetByIdPersonQuery, PersonDto>
    {
        public async Task<PersonDto> Handle(GetByIdPersonQuery request, CancellationToken cancellationToken)
        {
            var person = await personRepository.GetByIdAsync(request.Id)
                ?? throw new NotFoundException("No se encontró entidad");

            var personDto = PersonExtensions.ToPersonDto(person);

            return personDto;
        }
    }
}
