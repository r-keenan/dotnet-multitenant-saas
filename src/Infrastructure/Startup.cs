﻿using Finbuckle.MultiTenant;
using Infrastructure.Tenancy;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class Startup
{
    public static IServiceCollection AddMultitenancyServices(this IServiceCollection services, IConfiguration config)
    {
        return services.AddDbContext<TenantDbContext>(options =>
                        options.UseNpgsql(config.GetConnectionString("DefaultConnection")))
                .AddMultiTenant<ABCSchoolTenantInfo>()
                .WithHeaderStrategy("tenant")
                .WithClaimStrategy("tenant")
                .WithEFCoreStore<TenantDbContext, ABCSchoolTenantInfo>()
                .Services;

    }
}
