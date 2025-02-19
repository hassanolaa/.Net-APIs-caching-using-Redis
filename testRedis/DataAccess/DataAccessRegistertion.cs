using System.Runtime.CompilerServices;
using testRedis.data.contarcts;
using testRedis.data.repos;

namespace testRedis.data
{
    public static class DataAccessRegistertion
    {
        public static IServiceCollection RegisterDataAccess (this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>();
            services.AddScoped<UnitOfWork>();
            services.AddScoped<IUnitOfwork,UnitOfWork>();

            services.AddScoped<IProductRepo,ProductRepo>();
            services.AddScoped<ICatgeoryRepo,CatgeoryRepo>();

            return services;
        }
    }
}
