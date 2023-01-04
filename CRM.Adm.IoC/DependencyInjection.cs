using CRM.Adm.Domain.Interfaces;
using CRM.Adm.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CRM.Adm.Application.Interfaces;
using CRM.Adm.Application.Services;
using CRM.Adm.Application.Mappings;
using CRM.Adm.Infra.Data.Repositories;

namespace CRM.Adm.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), 
                                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))
             );

            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));
            return services;
        }
    }
}
