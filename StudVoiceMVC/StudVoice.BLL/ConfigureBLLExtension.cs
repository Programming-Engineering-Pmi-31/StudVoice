using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using StudVoice.BLL.Factories;
using StudVoice.BLL.Mappings;
using StudVoice.BLL.Services.ImplementedServices;
using StudVoice.BLL.Services.Interfaces;
using StudVoice.DAL;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace StudVoice.BLL
{
    public static class ConfigureBLLExtension
    {
        public static void ConfigureBLL(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureAutoMapper();
            services.ConfigureServices();

            services.AddScoped<IServiceFactory, ServiceFactory>();

            services.ConfigureDAL(configuration);
        }

        private static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }

        private static void ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddSingleton(new MapperConfiguration(c =>
            {
                c.AddProfile(new RoleProfile());
                c.AddProfile(new UserProfile());
            }).CreateMapper());
        }
    }
}
