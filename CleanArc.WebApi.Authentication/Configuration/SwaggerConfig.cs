using Microsoft.OpenApi.Models;

namespace CleanArc.WebApi.Autenthication.Configuration
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "WSM Sistemas Identity API",
                    Description = "Esta API faz parte da Aplicação de Treinamento em Asp Net Core Advanced",
                    Contact = new OpenApiContact() { Name = "WSM Sistemas", Email = "wsmtecnologia2021@gmail.com" },
                    License = new OpenApiLicense() { Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT") }
                });

            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();

            return app;
        }
    }
}