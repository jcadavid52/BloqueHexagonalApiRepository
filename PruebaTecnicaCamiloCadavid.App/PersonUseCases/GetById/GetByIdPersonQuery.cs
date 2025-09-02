using MediatR;
using PruebaTecnicaCamiloCadavid.App.Dtos;

namespace PruebaTecnicaCamiloCadavid.App.PersonUseCases.GetById
{
    public record GetByIdPersonQuery(int Id):IRequest<PersonDto>;
}
