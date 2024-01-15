
using Microsoft.Extensions.DependencyInjection;
using Elympics.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Elympics.Services.RandomNumberService;

namespace Elympics.DI;
public static class DependencyRegistration
{
public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<RandomNumberDbContext>(options =>
          options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IRandomumberRepository, RandomNumberRepository>();

          return services;
    }

    public static IServiceCollection AddRandomNumberServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IRandomNumberService, RandomNumberService>();
        
        services.AddHttpClient<RandomNumberHttpClient>(c => c.BaseAddress = new System.Uri(configuration.GetSection("Services")["RandomServiceBase"]));

          return services;
    }

}
