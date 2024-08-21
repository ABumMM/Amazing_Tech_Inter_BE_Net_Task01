using XuongMay.Mappers;
using XuongMay.Repositories.CRepository;
using XuongMay.Repositories.IRepository;
using XuongMay.Services.CServices;
using XuongMay.Services.IServices;

namespace XuongMay.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddConfiguration(this IServiceCollection services)
        {
            // Đăng ký các repository
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            // Đăng ký các services/
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IOrderService, OrderService>();

            // Đăng ký các mapper
            services.AddScoped<IOrderMapper, OrderMapper>();

            return services;
        }
    }
}
