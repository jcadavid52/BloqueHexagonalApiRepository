using MediatR;
using PruebaTecnicaCamiloCadavid.Domain.Models;
using PruebaTecnicaCamiloCadavid.Domain.Ports;
using PruebaTecnicaCamiloCadavid.Domain.ValueObjects;

namespace PruebaTecnicaCamiloCadavid.App.PersonUseCases.Create
{
    public class CreatePersonCommandHandler(
        IPersonRepository personRepository,
        IUnitOfWork unitOfWork
        ) : IRequestHandler<CreatePersonCommand, int>
    {
        public async Task<int> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            var person = Person.Create(
               request.FirstName.Trim(),
               request.LastName.Trim(),
               DocumentType.From(request.DocumentType.Trim()),
               request.Document.Trim(),
               request.Email.Trim(),
               request.BirthDate,
               request.Genero.Trim(),
               request.PhoneNumber.Trim()
            );

            await personRepository.Add(person);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return person.Id;
        }
    }
}
