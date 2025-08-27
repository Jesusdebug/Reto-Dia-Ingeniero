using Concurso.App.gestion.Application.Services;
using Concurso.App.gestion.Application.Services.Impl;
using Concurso.App.gestion.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Concurso.App.gestion.Web.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IProductoService, ProductoService>();
            services.AddScoped<IPedidoService, PedidoService>();
            services.AddScoped<IDetallePedidoService, DetallePedidoService>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }
    }
}
