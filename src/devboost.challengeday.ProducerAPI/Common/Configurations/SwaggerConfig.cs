using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace devboost.challengeday.ProducerAPI.Common.Configurations
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddSwaggerConfig(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Challenge Day",
                    Version = "v1",
                    Description = "Challenge Day",
                });
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Por favor insira um JWT com \"Bearer\" nesse campo",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
            });

            return services;
        }
    }
}