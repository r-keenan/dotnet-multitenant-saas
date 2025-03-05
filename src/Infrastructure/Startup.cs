using Infrastructure.Contexts;
using Finbuckle.MultiTenant;
using Infrastructure.Tenancy;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class Startup
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration config)
    {
        return services.AddDbContext<TenantDbContext>(options =>
                        options.UseNpgsql(config.GetConnectionString("DefaultConnection")))
                .AddMultiTenant<ABCSchoolTenantInfo>()
                .WithHeaderStrategy(TenancyConstants.TenantIdName)
                .WithClaimStrategy(TenancyConstants.TenantIdName)
                .WithEFCoreStore<TenantDbContext, ABCSchoolTenantInfo>()
                .Services
                .AddDbContext<ApplicationDbContext>(opts => opts.UseNpgsql(config.GetConnectionString("DefaultConnection")));

    }
    public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
    {
        return app.UseMultiTenant();
    }
}

