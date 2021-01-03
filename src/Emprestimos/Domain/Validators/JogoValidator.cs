using Emprestimos.Domain.Entities;
using FluentValidation;

namespace Emprestimos.Domain.Validators
{
    public class JogoValidator : AbstractValidator<Jogo>
    {
        public JogoValidator()
        {
            RuleFor(x => x.Nome).NotEmpty().WithMessage("Nome deve ser valido")
                                           .MaximumLength(100).WithMessage("Nome deve ter 100 caracteres");

            RuleFor(x => x.Genero).NotNull().WithMessage("Genero deve ser valido");
            RuleFor(x => x.Situacao).NotNull().WithMessage("Situação deve ser valido");
        }
    }
}
