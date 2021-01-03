using Emprestimos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Emprestimos.Data.Configurations
{
    public class JogoConfiguration : IEntityTypeConfiguration<Jogo>
    {
        public void Configure(EntityTypeBuilder<Jogo> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Genero).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Situacao).HasMaxLength(50).IsRequired();
        }
    }
}
