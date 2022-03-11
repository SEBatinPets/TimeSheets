using Microsoft.AspNetCore.Builder;

namespace TimeSheets.Infrastructure.StartupExtensions
{
    internal static class AppCollectionExtensions
    {
        public static void ConfigureSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API TimeSheets");
                c.RoutePrefix = string.Empty;
            });
        }
    }
}
