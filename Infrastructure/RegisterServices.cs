using Infrastructure.DataAccess;
using Infrastructure.DataAccess.Interceptor;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class RegisterServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddScoped<AuditableEntitySaveChangesInterceptor>();
        services.AddDbContext<ICatalogDbContext, CatalogDbContext>(x => x.UseNpgsql(configuration.GetConnectionString("PostgresDB")));
        services.AddScoped<IAddressRepository, AddressRepository>();
        services.AddScoped<IArenaRepository, ArenaRepository>();
        services.AddScoped<IOwnerRepository, OwnerRepository>();
        services.AddScoped<IPermissionRepository, PermissionRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IStadiumRepository, StadiumRepository>();
        services.AddScoped<ITimeRepository, TimeRepository>();
        return services;
    }
}