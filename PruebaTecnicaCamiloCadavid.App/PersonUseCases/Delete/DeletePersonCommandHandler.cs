using MediatR;
using PruebaTecnicaCamiloCadavid.App.Exceptions;
using PruebaTecnicaCamiloCadavid.Domain.Ports;

namespace PruebaTecnicaCamiloCadavid.App.PersonUseCases.Delete
{
    public class DeletePersonCommandHandler(
        IPersonRepository personRepository,
        IUnitOfWork unitOfWork
        ) : IRequestHandler<DeletePersonCommand>
    {
        public async Task Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            var person = await personRepository.GetByIdAsync(request.Id)
                ?? throw new NotFoundException("No se encontró entidad");

            personRepository.Delete(person);

            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
