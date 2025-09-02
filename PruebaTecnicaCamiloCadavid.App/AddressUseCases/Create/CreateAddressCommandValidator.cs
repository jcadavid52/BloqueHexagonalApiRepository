using FluentValidation;

namespace PruebaTecnicaCamiloCadavid.App.AddressUseCases.Create
{
    public class CreateAddressCommandValidator:AbstractValidator<CreateAddressCommand>
    {
        public CreateAddressCommandValidator()
        {
            RuleFor(x => x.Street)
            .NotEmpty().WithMessage("La calle es requerida")
            .NotNull().WithMessage("La calle no puede ser nula")
            .MinimumLength(3).WithMessage("La calle debe tener al menos 3 caracteres")
            .MaximumLength(100).WithMessage("La calle no puede superar los 100 caracteres");

            RuleFor(x => x.City)
                .NotEmpty().WithMessage("La ciudad es requerida")
                .NotNull().WithMessage("La ciudad no puede ser nula")
                .Matches("^[a-zA-ZáéíóúÁÉÍÓÚñÑ ]+$")
                    .WithMessage("La ciudad solo puede contener letras")
                .MinimumLength(2).WithMessage("La ciudad debe tener al menos 2 caracteres")
                .MaximumLength(50).WithMessage("La ciudad no puede superar los 50 caracteres");

            RuleFor(x => x.Country)
                .NotEmpty().WithMessage("El país es requerido")
                .NotNull().WithMessage("El país no puede ser nulo")
                .Matches("^[a-zA-ZáéíóúÁÉÍÓÚñÑ ]+$")
                    .WithMessage("El país solo puede contener letras")
                .MinimumLength(2).WithMessage("El país debe tener al menos 2 caracteres")
                .MaximumLength(50).WithMessage("El país no puede superar los 50 caracteres");

            RuleFor(x => x.IdPerson)
                .NotEmpty().WithMessage("El identificador de la persona es requerido")
                .NotNull().WithMessage("El identificador de la persona no puede ser nulo")
                .GreaterThan(0).WithMessage("El identificador de la persona debe ser mayor a 0");
        }
    }
}
