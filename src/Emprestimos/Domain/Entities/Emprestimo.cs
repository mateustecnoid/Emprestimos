using Emprestimos.Domain.Base;
using Emprestimos.Domain.Validators;
using System;

namespace Emprestimos.Domain.Entities
{
    public class Emprestimo : Entity
    {
        protected Emprestimo() { }

        public Emprestimo(Amigo amigo, Jogo jogo)
        {
            Amigo = amigo;
            Jogo = jogo;
            DataEmprestimo = DateTime.Now;
            Validar();
        }

        public Amigo Amigo { get; private set; }
        public Jogo Jogo { get; private set; }
        public DateTime DataEmprestimo { get; private set; }
        public DateTime? DataDevolucao { get; private set; }

        public void Devolver()
        {
            DataDevolucao = DataDevolucao ?? DateTime.Now;
            Jogo.Disponibilizar();
        }

        public void Atualizar(Amigo amigo, Jogo jogo)
        {
            Amigo = amigo;
            Jogo = jogo;
            Validar();
        }

        public override bool Validar()
        {
            return Validate(this, new EmprestimoValidator());
        }
    }
}
