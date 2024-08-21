using XuongMay.Repositories;
using XuongMay.Services;

namespace XuongMay.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddConfiguration(this IServiceCollection services)
        {
            // Đăng ký các repository
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>(); 

            // Đăng ký các services
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
