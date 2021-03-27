using ChatFlow.Dialog.Domain.Infrastructure.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ChatFlow.Dialog.Api.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddCustonConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<ChatFlowConfiguration>(configuration.GetSection("ChatFlowConfiguration").Get<ChatFlowConfiguration>());

            return services;
        }

        public static IServiceCollection AddHealthChecks(this IServiceCollection services, IConfiguration configuration)
        {
            //var hcBuilder = services.AddHealthChecks();
            //hcBuilder.AddCheck("self", () => HealthCheckResult.Healthy());

            return services;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Cable API", Version = "v1" });
            //});

            //services.AddSwaggerGenNewtonsoftSupport();

            return services;
        }
    }
}
