using devboost.challengeday.Services.Kafka;
using devboost.challengeday.Services.Kafka.Interfaces;
using devboost.challengeday.ProducerAPI.Common.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using devboost.challengeday.Services.Kafka.Config;
using devboost.challengeday.Shared.Middleware;

namespace devboost.challengeday.ProducerAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddApiVersioning();
            services.AddSwaggerConfig();
            services.Configure<KafkaConfig>(Configuration.GetSection("Kafka"));
            services.AddScoped<IKafkaProducer, KafkaProducer>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseMiddleware(typeof(ErrorHandlerMiddleware));

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "V1");
                options.RoutePrefix = string.Empty;
            });
        }
    }
}
