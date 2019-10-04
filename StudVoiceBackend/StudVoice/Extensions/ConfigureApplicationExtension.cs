using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudVoice.BLL;

namespace StudVoice.API.Extensions
{
    public static class ConfigureApplicationExtension
    {
        public static void ConfigureApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureBLL(configuration);
        }
    }
}
