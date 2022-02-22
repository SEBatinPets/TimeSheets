using DomainLibrary.Domain.Managers.Implementation;
using DomainLibrary.Domain.Managers.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using RepositoriesLibrary.Repositories.Implementation;
using RepositoriesLibrary.Repositories.Interfaces;

namespace TimeSheets.Infrastructure.StartupExtensions
{
    internal static class ServiceCollectionExtensions
    {
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API TimeSheets",
                    Version = "v1"
                });
            });
        }
        public static void ConfigureManagers(this IServiceCollection services)
        {
            services.AddSingleton<IPersonManager, PersonManager>();
        }
        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddSingleton<IPersonRepository, PersonRepository>();
        }
    }
}
