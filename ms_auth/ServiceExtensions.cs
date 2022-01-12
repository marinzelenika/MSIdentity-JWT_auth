﻿using Microsoft.AspNetCore.Identity;
using ms_auth.Data;
using ms_auth.Helpers;

namespace ms_auth
{
    public static class ServiceExtensions
    {
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentityCore<ApiUser>(q => q.User.RequireUniqueEmail = true);
            builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole), services);
            builder.AddEntityFrameworkStores<DataContext>().AddDefaultTokenProviders();
        }
    }
}
