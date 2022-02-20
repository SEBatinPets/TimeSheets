using DomainLibrary.Domain.Managers.Implementation;
using DomainLibrary.Domain.Managers.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using RepositoriesLibrary.Data.Ef.DbContexts;
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
            services.AddSingleton<IEmployeeManager, EmployeeManager>();
            services.AddSingleton<IUserManager, UserManager>();
        }
        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddSingleton<IEmployeeRepository, EmployeeRepository>();
            services.AddSingleton<IUserRepository, UserRepository>();
        }
        public static void ConfigureDb(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<TimeSheetsDbContext>(options => options.UseSqlite(connectionString));
        }
    }
}
