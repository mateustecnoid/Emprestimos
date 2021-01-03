using Emprestimos.Application.Notify;
using Emprestimos.Application.Services;
using Emprestimos.Application.Services.Interfaces;
using Emprestimos.Configuration;
using Emprestimos.Configuration.Interfaces;
using Emprestimos.Data;
using Emprestimos.Domain.Validators;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Emprestimos.Application
{
    public static class ApplicationDependencyContext
    {
        public static void ConfigureApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<EmprestimosContext>();
            services.AddScoped<NotificationContext>();
            services.AddScoped<IJwtConfig, JwtConfig>();
            services.AddScoped<IEntityValidator, EntityValidator>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IJogoService, JogoService>();
            services.AddScoped<IAutenticacaoService, AutenticacaoService>();
            services.AddScoped<IAmigoService, AmigoService>();
            services.AddScoped<IEmprestimoService, EmprestimoService>();
        }
    }
}
