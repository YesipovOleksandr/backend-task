using ConsoleApp.BLL.Services;
using ConsoleApp.Common.Abstract;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleApp.Dependencies
{
    public static class DependencyRegistrator
    {
        public static void RegisterDependencyModules(IServiceCollection services)
        {
            services.AddTransient<IBackendTask, ThreadBackendTask>();
            services.AddTransient<IBackendTask, ExpressionBackendTask>();
            services.AddTransient<IApp,App>();
        }
    }
}
