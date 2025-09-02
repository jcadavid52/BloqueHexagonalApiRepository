using FluentValidation;

namespace PruebaTecnicaCamiloCadavid.App.PersonUseCases.Create
{
    public class CreatePersonCommandValidator:AbstractValidator<CreatePersonCommand>
    {
        public CreatePersonCommandValidator()
        {
            RuleFor(x => x.FirstName)
            
            .NotEmpty().WithMessage("El nombre es requerido")
            .NotNull().WithMessage("El nombre no puede ser nulo")
            .Matches("^[a-zA-ZáéíóúÁÉÍÓÚñÑ ]+$")
                .WithMessage("El nombre solo puede contener letras")
            .MinimumLength(2).WithMessage("El nombre debe tener al menos 2 caracteres")
            .MaximumLength(50).WithMessage("El nombre no puede superar los 50 caracteres");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("El apellido es requerido")
                .NotNull().WithMessage("El apellido no puede ser nulo")
                .Matches("^[a-zA-ZáéíóúÁÉÍÓÚñÑ ]+$")
                    .WithMessage("El apellido solo puede contener letras")
                .MinimumLength(2).WithMessage("El apellido debe tener al menos 2 caracteres")
                .MaximumLength(50).WithMessage("El apellido no puede superar los 50 caracteres");

            RuleFor(x => x.DocumentType)
                .NotEmpty().WithMessage("El tipo de documento es requerido")
                .NotNull().WithMessage("El tipo de documento no puede ser nulo");

            RuleFor(x => x.Document)
                .NotEmpty().WithMessage("El documento es requerido")
                .NotNull().WithMessage("El documento no puede ser nulo")
                .Matches(@"^\d+$").WithMessage("El documento solo debe contener números");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("El correo es requerido")
                .NotNull().WithMessage("El correo no puede ser nulo")
                .EmailAddress().WithMessage("El correo no tiene un formato válido");

            RuleFor(x => x.BirthDate)
                .NotEmpty().WithMessage("La fecha de nacimiento es requerida")
                .NotNull().WithMessage("La fecha de nacimiento no puede ser nula")
                .LessThan(DateOnly.FromDateTime(DateTime.Now))
                    .WithMessage("La fecha de nacimiento debe ser anterior a la fecha actual");

            RuleFor(x => x.Genero)
                .NotEmpty().WithMessage("El género es requerido")
                .NotNull().WithMessage("El género no puede ser nulo");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("El número de teléfono es requerido")
                .NotNull().WithMessage("El número de teléfono no puede ser nulo")
                .Matches(@"^\d{10}$").WithMessage("El número de teléfono debe tener exactamente 10 dígitos");
        }
    }
}
