using AutoMapper;
using Core.AutoMapper;
using Core.Helpers;
using Core.Interfaces.APIService;
using Core.Interfaces.CustomService;
using Core.Services;
using Core.Services.AdditionalAPI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Core
{
    public static class ServiceExtensions
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IDocumentService, DocumentService>();
            services.AddScoped<IHistoryService, HistoryService>();
        }

        public static void AddAutoMapper(this IServiceCollection services)
        {
            var configures = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new UserProfiles());
                mc.AddProfile(new ProjectProfile());
                mc.AddProfile(new DocumentProfile());
                mc.AddProfile(new HistoryProfile());
            });
            var mapper = configures.CreateMapper();
            services.AddSingleton(mapper);
        }

        public static void ConfigJwtOptions(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<JwtOptions>(config.GetSection("JwtOptions"));
            services.Configure<TranslationMemory>(config.GetSection("TranslationMemory"));
        }

        public static void Configures(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<AppSettings>(config);
        }

        public static void AddHttpClients(this IServiceCollection services)
        {
            services.AddHttpClient<ITranslationService, TranslationService>();
        }
    }
}
