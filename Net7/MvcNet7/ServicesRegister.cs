using MvcNet7.Interfaces;
using MvcNet7.Repository;

namespace MvcNet7
{
    public static class ServicesRegister
    {
        public static void RegisterService(this IServiceCollection services)
        {
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<ILogRepository, LogRepository>();
            //services.AddScoped(typeof(IVietNamShapeService), typeof(VietNameShapeService));
            //services.AddScoped(typeof(IRoadNameService), typeof(RoadNameService));
        }
    }
}
