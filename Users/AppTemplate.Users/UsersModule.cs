﻿using AppTemplate.UserManagement.Authentication;
using AppTemplate.Users.Database;
using AppTemplate.Users.UserManagement;
using Core.Database;
using Core.Web.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AppTemplate.Users
{
    public class UsersModule : ITopLevelModule
    {
        public void Register(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Database");
            services.AddDbContext<UsersDataContext>(o => o.UseSqlServer(connectionString));

            services.AddScoped<ICurrentUserLocator, CurrentUserLocator>();
            services.RegisterModule<UserManagementModule>();
        }
    }
}
