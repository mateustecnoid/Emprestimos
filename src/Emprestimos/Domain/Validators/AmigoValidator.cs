using Emprestimos.Domain.Entities;
using FluentValidation;

namespace Emprestimos.Domain.Validators
{
    public class AmigoValidator : AbstractValidator<Amigo>
    {
        public AmigoValidator()
        {
            RuleFor(x => x.Apelido).NotEmpty().WithMessage("Apelido deve ser valido")
                                   .MaximumLength(100).WithMessage("Apelido deve ter 100 caracteres");

            RuleFor(x => x.Telefone).NotEmpty().WithMessage("Telefone deve ser valido")
                                    .MaximumLength(25).WithMessage("Telefone deve ter 25 caracteres");
        }
    }
}
