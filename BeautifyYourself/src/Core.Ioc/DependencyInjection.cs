using Core.Core;
using Core.Core.Application.Auth;
using Core.Core.Domain;
using Core.Core.Domain.Auth;
using Core.Repository;
using Core.Repository.Auth;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Ioc
{
    public static class DependencyInjection
    {
        public static void Register(IServiceCollection services)
        {
            RegisterApplication(services);
            RegisterRepository(services);
            RegisterOthers(services);
        }

        private static void RegisterApplication(IServiceCollection services)
        {
            services.AddScoped<IAuthApplication, AuthApplication>();
        }

        private static void RegisterRepository(IServiceCollection services)
        {
            services.AddScoped<Context>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAuthRepository, AuthRepository>();
        }

        private static void RegisterOthers(IServiceCollection services)
        {
            services.AddScoped<ErrorEvent>();
        }
    }
}
