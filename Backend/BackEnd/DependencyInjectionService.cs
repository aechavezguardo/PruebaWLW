using BackEnd.Context;
using BackEnd.Repositories;
using BackEnd.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BackEnd
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddExternal(this IServiceCollection services, IConfiguration _configuration)
        {
            string connectionString = "";
            connectionString = _configuration["ConnectionStrings:SQLConnectionStrings"].ToString();

            services.AddDbContext<DevLabContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IClientesRepository, ClientesRepository>();
            services.AddScoped<IFacturasRepository, FacturasRepository>();

            return services;
        }
    }
}
