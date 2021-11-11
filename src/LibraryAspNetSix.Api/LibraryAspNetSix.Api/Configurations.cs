using Microsoft.OpenApi.Models;

namespace LibraryAspNetSix.Api
{
    public static class Configurations
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Library Asp.Net Six",
                    Version = "v1"
                });
            });
        }

        public static void UseDefaultSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = string.Empty;
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Library Asp.Net Six");
            });
        }
    }
}
