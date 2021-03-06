using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

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
    }
}
