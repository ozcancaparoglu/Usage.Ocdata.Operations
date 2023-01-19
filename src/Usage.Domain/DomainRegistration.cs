using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ocdata.Operations.Authentication;
using Ocdata.Operations.Cache.Redis;
using Usage.Domain.Persistence;

namespace Usage.Domain
{
    public static class DomainRegistration
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("CategoryConnectionString")));

            services.Configure<RedisConfigurationOptions>(configuration.GetSection("RedisDatabase"));

            services.Configure<JwtConfigurationOptions>(configuration.GetSection("Jwt"));

            services.AddScoped<DbContext, AppDbContext>();

            return services;
        }
    }
}
