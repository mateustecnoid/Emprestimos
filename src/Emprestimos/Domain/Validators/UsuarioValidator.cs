using Emprestimos.Domain.Entities;
using FluentValidation;

namespace Emprestimos.Domain.Validators
{
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        public UsuarioValidator()
        {
            RuleFor(x => x.Nome).NotEmpty().WithMessage("Nome deve ser valido")
                                .MaximumLength(100).WithMessage("Nome deve ter 100 caracteres");

            RuleFor(x => x.Senha).NotEmpty().WithMessage("Senha deve ser valido")
                                 .MaximumLength(30).WithMessage("Senha deve ter 30 caracteres");

            RuleFor(x => x.Email).NotEmpty().WithMessage("E-Mail deve ser valido")
                                 .MaximumLength(100).WithMessage("E-Mail deve ter 100 caracteres");
        }
    }
}
