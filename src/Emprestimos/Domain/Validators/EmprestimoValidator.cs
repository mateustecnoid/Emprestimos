using Emprestimos.Domain.Entities;
using FluentValidation;
using System;

namespace Emprestimos.Domain.Validators
{
    public class EmprestimoValidator : AbstractValidator<Emprestimo>
    {
        public EmprestimoValidator()
        {
            RuleFor(x => x.Amigo).NotNull().WithMessage("Amigo deve ser valido");
            RuleFor(x => x.Jogo).NotNull().WithMessage("Jogo deve ser valido");
            RuleFor(x => x.DataEmprestimo).Must(DataValida).WithMessage("Data de emprestimo não pode ser menor que o dia atual");
            RuleFor(x => x.DataDevolucao).GreaterThanOrEqualTo(y => y.DataEmprestimo).When(z => z.DataDevolucao.HasValue)
                                         .WithMessage("Data de devolução não pode ser menor que a data de emprestimo");

        }

        private static bool DataValida(DateTime data) => data.Date >= DateTime.Now.Date;
    }
}
