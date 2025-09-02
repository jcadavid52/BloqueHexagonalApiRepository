using FluentValidation;

namespace PruebaTecnicaCamiloCadavid.App.RolePersonUseCases.CreateRolePerson
{
    public class CreateRolePersonCommandValidator:AbstractValidator<CreateRolePersonCommand>
    {
        public CreateRolePersonCommandValidator()
        {
            RuleFor(x => x.IdRole)
              .NotEmpty().WithMessage("El identificador del rol es requerido")
              .NotNull().WithMessage("El identificador del rol no puede ser nulo")
              .GreaterThan(0).WithMessage("El identificador del rol debe ser mayor a 0");

            RuleFor(x => x.IdPerson)
              .NotEmpty().WithMessage("El identificador de la persona es requerido")
              .NotNull().WithMessage("El identificador de la persona no puede ser nulo")
              .GreaterThan(0).WithMessage("El identificador de la persona debe ser mayor a 0");
        }
    }
}
