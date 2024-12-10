using FluentValidation;
using Serilog;
using T9Spelling.Models.RequestModels;
using T9Spelling.Models.ValidationModels;
using T9Spelling.Services.Abstraction;
using T9Spelling.Services.Implementation;

namespace T9Spelling.Extensions
{
    public static class DIExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IT9SpellingService, T9SpellingService>();

            return services;
        }

        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<T9SpellingRequestModel>, T9ValidationModel>();

            return services;
        }

        public static IServiceCollection AddLogger(this IServiceCollection services)
        {
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .CreateLogger();

            services.AddSingleton(Log.Logger);

            return services;
        }
    }
}
