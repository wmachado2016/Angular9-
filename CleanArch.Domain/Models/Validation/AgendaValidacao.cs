using FluentValidation;

namespace CleanArch.Domain.Models.Validations
{
    public class AgendaValidacao : AbstractValidator<Agenda>
    {
        public AgendaValidacao()
        {
            RuleFor(c => c.DataAgenda)
                .NotEmpty().WithMessage("Por favor, certifique-se de ter inserido o Data");

            RuleFor(c => c.ServicoId)
                .NotEmpty().WithMessage("Por favor, certifique-se de ter inserido o Servico");

            RuleFor(c => c.ClienteId).NotEmpty().WithMessage("Por favor, certifique-se de ter inserido o Cliente");
        }

    }
}