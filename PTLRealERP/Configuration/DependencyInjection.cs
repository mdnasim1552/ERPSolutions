using RealERPLIB.ControllersRepository;
using RealERPLIB.DapperRepository;

namespace PTLRealERP.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAllRepository(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}
