using Microsoft.Extensions.DependencyInjection;

namespace StudVoice.API.Extensions
{
    public static class CorsExtension
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options => options
                .AddPolicy("CorsPolicy", x => x
                    .AllowAnyHeader()
                    .AllowCredentials()
                    .AllowAnyMethod()));
        }
    }
}
