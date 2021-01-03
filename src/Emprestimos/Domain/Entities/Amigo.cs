using Emprestimos.Domain.Base;
using Emprestimos.Domain.Enum;
using Emprestimos.Domain.Validators;
using System.Collections.Generic;
using System.Linq;

namespace Emprestimos.Domain.Entities
{
    public class Amigo : Entity
    {
        protected Amigo() { }

        public Amigo(string apelido, string telefone)
        {
            Apelido = apelido;
            Telefone = telefone;
            Validar();
        }

        public string Apelido { get; private set; }
        public string Telefone { get; private set; }

        private readonly List<Emprestimo> _emprestimos = new List<Emprestimo>();
        public IReadOnlyCollection<Emprestimo> Emprestimos => _emprestimos;

        public void AddEmprestimo(Emprestimo emprestimo)
        {
            if (_emprestimos.Any(x => x.Jogo.Id == emprestimo.Jogo.Id && x.Jogo.Situacao == SituacaoJogo.Indisponivel && !x.DataDevolucao.HasValue))
                return;

            emprestimo.Jogo.Indisponilizar();

            _emprestimos.Add(emprestimo);
        }

        public void FinalizarEmprestimo(long emprestimoId)
        {
            var emprestimo = _emprestimos.FirstOrDefault(x => x.Id == emprestimoId);

            if (emprestimo == null)
            {
                AddValidationResult("Emprestimo", "Emprestimo não foi encontrado");
                return;
            }

            emprestimo.Jogo.Disponibilizar();

            _emprestimos.Remove(emprestimo);
        }

        public void FinalizarTodosEmprestimo()
        {
            foreach (var emprestimo in _emprestimos)
                emprestimo.Devolver();

            _emprestimos.Clear();
        }

        public void DevolverTodosJogos()
        {
            foreach (var emprestimo in _emprestimos.Where(x => !x.DataDevolucao.HasValue))
                emprestimo.Devolver();
        }

        public void Atualizar(string apelido, string telefone)
        {
            Apelido = apelido;
            Telefone = telefone;
            Validar();
        }

        public override bool Validar()
        {
            return Validate(this, new AmigoValidator());
        }
    }
}
