using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Usage.Application.Services;
using Usage.Application.Services.BaseServices;

namespace Usage.Application
{
    public static class ApplicationRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICategoryAttributeService, CategoryAttributeService>();
            services.AddScoped<IUserService, UserService>();

            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }
    }
}
