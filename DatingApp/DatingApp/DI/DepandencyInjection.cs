using DatingApp.Helper;
using DatingApp.Interface;
using Items.Infrastructure;
using Items.Infrastructure.Repository.AccountRepo;
using Microsoft.Extensions.DependencyInjection;

namespace DatingApp.DI
{
    public static class DepandencyInjection
    {
        //services.AddScoped(typeof(IAccountRepository), typeof(AccountRepository));
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            //GenarateToken
            services.AddTransient<GenarateToken, GenarateToken>();

            return services;
        }

    }
}
