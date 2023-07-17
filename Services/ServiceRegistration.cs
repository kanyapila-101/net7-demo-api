using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using net7_demo_api.Services.Users;

namespace net7_demo_api.Services
{
    public static class ServiceRegistration
    {
        public static void AddMyService(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
        {
            
            //var config = TypeAdapterConfig.GlobalSettings;
            //config.Scan(Assembly.GetExecutingAssembly()!);
            //config.Default.PreserveReference(true); // circular loop ref.
            //services.AddSingleton(config);
            services.AddScoped<IUserService, UserService>();
            AddServices(ref services);     
        }

        private static void AddServices(ref IServiceCollection services)
        {
            //services.AddScoped<Shared.Services.ShareUrlService>();
            //services.AddSingleton<Shared.Services.TMSUploadS3>();
        }
    }
}