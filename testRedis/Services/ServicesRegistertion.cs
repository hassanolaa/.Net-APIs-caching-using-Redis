using testRedis.Services.contarcts;
using testRedis.Services.ServiceRepos;

namespace testRedis.Services
{
    public static class ServicesRegistertion
    {
        public static IServiceCollection ServiceRegister(this IServiceCollection services)
        {
            services.AddScoped<IProductServices,ProductServices>();
            services.AddScoped<ICategoryServices,CategoryServices>();

            return services;
        }
    }
}
