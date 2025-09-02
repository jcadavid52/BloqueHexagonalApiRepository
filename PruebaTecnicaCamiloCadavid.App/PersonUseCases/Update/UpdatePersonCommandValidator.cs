using FluentValidation;

namespace PruebaTecnicaCamiloCadavid.App.PersonUseCases.Update
{
    public class UpdatePersonCommandValidator:AbstractValidator<UpdatePersonCommand>
    {
        public UpdatePersonCommandValidator()
        {
            RuleFor(x => x.FirstName)
               .NotEmpty()
               .When(x => x.FirstName != null)
               .WithMessage("Este campo no puede estar vacío");

            RuleFor(x => x.LastName)
               .NotEmpty()
               .When(x => x.LastName != null)
               .WithMessage("Este campo no puede estar vacío");

            RuleFor(x => x.DocumentType)
               .NotEmpty()
               .When(x => x.DocumentType != null)
               .WithMessage("Este campo no puede estar vacío");

            RuleFor(x => x.Document)
               .NotEmpty()
               .When(x => x.Document != null)
               .WithMessage("Este campo no puede estar vacío");

            RuleFor(x => x.Email)
               .NotEmpty()
               .When(x => x.Email != null)
               .WithMessage("Este campo no puede estar vacío");

            RuleFor(x => x.BirthDate)
               .NotEmpty()
               .When(x => x.BirthDate != null)
               .WithMessage("Este campo no puede estar vacío");

            RuleFor(x => x.Genero)
               .NotEmpty()
               .When(x => x.Genero != null)
               .WithMessage("Este campo no puede estar vacío");

            RuleFor(x => x.PhoneNumber)
               .NotEmpty()
               .When(x => x.PhoneNumber != null)
               .WithMessage("Este campo no puede estar vacío");
        }
    }
}
