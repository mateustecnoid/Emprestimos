using Emprestimos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Emprestimos.Data.Configurations
{
    public class AmigoConfiguration : IEntityTypeConfiguration<Amigo>
    {
        public void Configure(EntityTypeBuilder<Amigo> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Apelido).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Telefone).HasMaxLength(25).IsRequired();

            builder.HasMany(x => x.Emprestimos)
                   .WithOne(x => x.Amigo)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
