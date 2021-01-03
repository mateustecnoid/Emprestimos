using Emprestimos.Domain.Entities;
using Emprestimos.Domain.Enum;
using FluentAssertions;
using Xunit;

namespace Emprestimos.Test.Unit.Entities
{
    public class JogoTest
    {
        private string nome = "Cyberpunk 2077";
        private GeneroEnum genero = GeneroEnum.RPG;

        [Fact]
        public void DeveCriarJogoValido()
        {
            var jogo = new Jogo(nome, genero, SituacaoJogo.Disponivel);
            jogo.Should().NotBeNull();
            jogo.Valid.Should().BeTrue();
            jogo.Nome.Should().Be(nome);
            jogo.Genero.Should().Be(genero);
            jogo.Situacao.Should().Be(SituacaoJogo.Disponivel);
        }

        [Fact]
        public void DeveCriarJogoInvalidoComNomeVazio()
        {
            var jogo = new Jogo(string.Empty, genero, SituacaoJogo.Disponivel);
            jogo.Should().NotBeNull();
            jogo.Valid.Should().BeFalse();
            jogo.Nome.Should().Be(string.Empty);
            jogo.Genero.Should().Be(genero);
            jogo.Situacao.Should().Be(SituacaoJogo.Disponivel);
        }

        [Fact]
        public void DadoUmJogoValidoDeveAtualizar()
        {
            var jogo = new Jogo(nome, genero, SituacaoJogo.Disponivel);
            jogo.Should().NotBeNull();
            jogo.Valid.Should().BeTrue();

            jogo.Atualizar("Forza Horizon 4", GeneroEnum.Corrida, SituacaoJogo.Indisponivel);

            jogo.Nome.Should().NotBe(nome);
            jogo.Genero.Should().NotBe(genero);
            jogo.Situacao.Should().NotBe(SituacaoJogo.Disponivel);
        }

        [Fact]
        public void DadoUmJogoValidoDisponivelDevoIndisponilizarParaEmprestimo()
        {
            var jogo = new Jogo(nome, genero, SituacaoJogo.Disponivel);
            jogo.Should().NotBeNull();
            jogo.Valid.Should().BeTrue();

            jogo.Indisponilizar();

            jogo.Situacao.Should().Be(SituacaoJogo.Indisponivel);
        }

        [Fact]
        public void DadoUmJogoValidoIndisponivelDevoDisponilizarParaEmprestimo()
        {
            var jogo = new Jogo(nome, genero, SituacaoJogo.Indisponivel);
            jogo.Should().NotBeNull();
            jogo.Valid.Should().BeTrue();

            jogo.Disponibilizar();

            jogo.Situacao.Should().Be(SituacaoJogo.Disponivel);
        }
    }
}
