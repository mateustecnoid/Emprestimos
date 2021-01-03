using Emprestimos.Domain.Base;
using Emprestimos.Domain.Enum;
using Emprestimos.Domain.Validators;
using System.Collections.Generic;

namespace Emprestimos.Domain.Entities
{
    public class Jogo : Entity
    {
        protected Jogo() { }

        public Jogo(string nome, GeneroEnum genero, SituacaoJogo situacao)
        {
            Nome = nome;
            Genero = genero;
            Situacao = situacao;
            Validar();
        }

        public string Nome { get; private set; }
        public GeneroEnum Genero { get; private set; }
        public SituacaoJogo Situacao { get; private set; }
        private readonly List<Emprestimo> _emprestimos = new List<Emprestimo>();
        public IReadOnlyCollection<Emprestimo> Emprestimos => _emprestimos;

        public void Disponibilizar() => Situacao = SituacaoJogo.Disponivel;
        public void Indisponilizar() => Situacao = SituacaoJogo.Indisponivel;

        public void Atualizar(string nome, GeneroEnum genero, SituacaoJogo situacao)
        {
            Nome = nome;
            Genero = genero;
            Situacao = situacao;
            Validar();
        }

        public override bool Validar()
        {
            return Validate(this, new JogoValidator());
        }
    }
}
