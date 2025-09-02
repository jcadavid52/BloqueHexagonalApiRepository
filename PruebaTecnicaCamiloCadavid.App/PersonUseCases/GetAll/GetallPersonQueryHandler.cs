using MediatR;
using PruebaTecnicaCamiloCadavid.App.Extensions;
using PruebaTecnicaCamiloCadavid.Domain.Ports;

namespace PruebaTecnicaCamiloCadavid.App.PersonUseCases.GetAll
{
    public class GetallPersonQueryHandler(IPersonRepository personRepository) : IRequestHandler<GetAllPersonQuery, GetAllPersonResponse>
    {
        public async Task<GetAllPersonResponse> Handle(GetAllPersonQuery request, CancellationToken cancellationToken)
        {
            var people = await personRepository.GetAllAsync();

            var peopleDto = PersonExtensions.ToPersonDtoList(people);

            return new GetAllPersonResponse(peopleDto);
        }
    }
}
