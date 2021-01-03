using System.ComponentModel;

namespace Emprestimos.Domain.Enum
{
    public enum GeneroEnum
    {
        [Description("Ação")]
        Acao,
        [Description("Aventura")]
        Aventura,
        [Description("Estratégia")]
        Estrategia,
        [Description("RPG")]
        RPG,
        [Description("Esporte")]
        Esporte,
        [Description("Corrida")]
        Corrida,
        [Description("On-line")]
        Online,
        [Description("Simulação")]
        Simulacao,
        [Description("Outros")]
        Outros
    }
}
