using Emprestimos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Emprestimos.Data
{
    public class EmprestimosContext : DbContext
    {
        public EmprestimosContext(DbContextOptions<EmprestimosContext> options) : base(options) { }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Amigo> Amigo { get; set; }
        public DbSet<Jogo> Jogo { get; set; }
        public DbSet<Emprestimo> Emprestimo { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Ignore<ValidationResult>();

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
