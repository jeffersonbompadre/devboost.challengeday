namespace devboost.challengeday.API
{
    using devboost.challengeday.API.Common.Configurations;
    using devboost.challengeday.Infra.Data;
    using devboost.challengeday.IoC;
    using devboost.challengeday.Shared.Middleware;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware(typeof(ErrorHandlerMiddleware));

            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            app.UseSwagger();
            app.UseSwaggerUI(
                options =>
                    {
                        options.SwaggerEndpoint("/swagger/v1/swagger.json", "V1");
                        options.RoutePrefix = string.Empty;
                    });
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<MongoDbConfig>(Configuration.GetSection("Mongo"));
            services.AddTransient<BankMongoDbContext>();
            services.AddControllers();
            services.AddApiVersioning();
            services.AddSwaggerConfig();
            services.ResolveDependencies(this.Configuration);
        }
    }
}