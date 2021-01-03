using Emprestimos.Domain.Entities;
using Emprestimos.Domain.Enum;
using FluentAssertions;
using System;
using Xunit;

namespace Emprestimos.Test.Unit.Entities
{
    public class EmprestimoTest
    {
        private Amigo amigo = new Amigo("Apelido do Amigo", "(27)99999-9999");
        private Jogo jogo = new Jogo("Forza Horizon 4", GeneroEnum.Corrida, SituacaoJogo.Disponivel);

        [Fact]
        public void DeveInstaciarEmprestimoValido()
        {
            var emprestimo = new Emprestimo(amigo, jogo);
            emprestimo.Should().NotBeNull();
            emprestimo.Valid.Should().BeTrue();
            emprestimo.Jogo.Nome.Should().Be(jogo.Nome);
            emprestimo.Amigo.Apelido.Should().Be(amigo.Apelido);
            emprestimo.DataEmprestimo.Date.Should().Be(DateTime.Now.Date);
        }

        [Fact]
        public void DeveInstaciarEmprestimoInvalidoComJogoNulo()
        {
            var emprestimo = new Emprestimo(amigo, null);
            emprestimo.Should().NotBeNull();
            emprestimo.Valid.Should().BeFalse();
            emprestimo.Jogo.Should().Be(null);
            emprestimo.Amigo.Apelido.Should().Be(amigo.Apelido);
            emprestimo.DataEmprestimo.Date.Should().Be(DateTime.Now.Date);
        }

        [Fact]
        public void DadoUmEmprestimoValidoDeveDisponiblizarOJogoParaEmprestimo()
        {
            var emprestimo = new Emprestimo(amigo, jogo);
            emprestimo.Should().NotBeNull();
            emprestimo.Valid.Should().BeTrue();

            emprestimo.Devolver();

            emprestimo.DataDevolucao.HasValue.Should().BeTrue();
        }
    }
}
