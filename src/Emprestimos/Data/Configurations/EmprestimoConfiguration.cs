using Emprestimos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Emprestimos.Data.Configurations
{
    public class EmprestimoConfiguration : IEntityTypeConfiguration<Emprestimo>
    {
        public void Configure(EntityTypeBuilder<Emprestimo> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.DataEmprestimo).IsRequired();
            builder.Property(x => x.DataDevolucao).IsRequired(false);

            builder.HasOne(x => x.Amigo)
                   .WithMany(x => x.Emprestimos);

            builder.HasOne(x => x.Jogo)
                   .WithMany(x => x.Emprestimos);            
        }
    }
}
