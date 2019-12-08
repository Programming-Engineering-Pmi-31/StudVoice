using System;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using StudVoice.DAL;

namespace StudVoice.API.Extensions
{
    public static class SeedExtension
    {
        public static void Seed(
            this IApplicationBuilder app,
            IServiceProvider services,
            IHostingEnvironment env)
        {
            app.SeedEssentialAsync(services).Wait();
            if (env.IsDevelopment())
            {
                app.SeedAdditionalAsync(services).Wait();
            }
        }
    }
}