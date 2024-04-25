using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AutomatApp.Application.ApplicationDependencies
{
    public static class ServiceCollectionExtencion
    {
        public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
        {
            services.AddMediatR(m => m.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
