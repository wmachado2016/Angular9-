using FluentValidation;

namespace CleanArch.Domain.Models.Validations
{
    public class CategoriaValidacao : AbstractValidator<Categoria>
    {
        public CategoriaValidacao()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 20).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}