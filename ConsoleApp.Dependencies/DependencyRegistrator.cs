using ConsoleApp.BLL.Services;
using ConsoleApp.Common.Abstract;
using Microsoft.Extensions.DependencyInjection;
using ReportApi.Common;

namespace ConsoleApp.Dependencies
{
    public static class DependencyRegistrator
    {
        public static void RegisterDependencyModules(IServiceCollection services)
        {
            services.AddKeyedTransient<IBackendTask, ThreadBackendTask>(ServiceKeys.TB);
            services.AddKeyedTransient<IBackendTask, ExpressionBackendTask>(ServiceKeys.EB);
            services.AddTransient<IRecordService, ConsoleRecordService>();
            services.AddTransient<IRecordService, LoggerRecordService>();
            services.AddTransient<IApp,App>();
        }
    }
}
