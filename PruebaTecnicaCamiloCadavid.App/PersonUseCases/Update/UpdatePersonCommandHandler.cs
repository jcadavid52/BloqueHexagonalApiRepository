using MediatR;
using PruebaTecnicaCamiloCadavid.App.Exceptions;
using PruebaTecnicaCamiloCadavid.App.Extensions;
using PruebaTecnicaCamiloCadavid.Domain.Ports;
using PruebaTecnicaCamiloCadavid.Domain.ValueObjects;

namespace PruebaTecnicaCamiloCadavid.App.PersonUseCases.Update
{
    public class UpdatePersonCommandHandler(
        IPersonRepository personRepository,
        IUnitOfWork unitOfWork
        ) : IRequestHandler<UpdatePersonCommand, UpdatePersonCommandResponse>
    {
        public async Task<UpdatePersonCommandResponse> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            var person = await personRepository.GetByIdAsync(request.Id) ?? throw new NotFoundException("No se encontró recurso");

            person.Update(
              request.Id,
              request.FirstName!.Trim() ?? person.FirstName,
              request.LastName!.Trim() ?? person.LastName,
              DocumentType.From(request.DocumentType!.Trim() ?? person.DocumentType.Value),
              request.Document!.Trim() ?? person.Document,
              request.Email!.Trim() ?? person.Email,
              request.BirthDate ?? person.BirthDate,
              request.Genero!.Trim() ?? person.Genero,
              request.PhoneNumber!.Trim() ?? person.PhoneNumber
            );

            await unitOfWork.SaveChangesAsync(cancellationToken);

            var personDto = PersonExtensions.ToPersonDto(person);

            return new UpdatePersonCommandResponse(personDto);
        }
    }
}
