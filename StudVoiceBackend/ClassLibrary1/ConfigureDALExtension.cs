﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace StudVoice.DAL
{
    public static class ConfigureDALExtension
    {
        public static void ConfigureDAL(
            this IServiceCollection services,
            IConfiguration configuration)
        {

            services.ConfigureDbContext(configuration);
            services.ConfigureIdentity();

        }



        private static void ConfigureDbContext(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            void ConfigureConnection(DbContextOptionsBuilder options)
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("StudVoice.DAL"));
            }

            services.AddDbContext<StudVoiceDBContext>(ConfigureConnection);
        }

        private static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<User, Role>(options => options.Stores.MaxLengthForKeys = 128)
                .AddEntityFrameworkStores<StudVoiceDBContext>()
                .AddRoleManager<RoleManager<Role>>()
                .AddUserManager<UserManager<User>>();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;
            });
        }
    }
}
