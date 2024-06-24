using ConsoleApp.BLL.Services;
using ConsoleApp.Common.Abstract;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ReportApi.Common;

namespace ConsoleApp.Dependencies
{
    public static class DependencyRegistrator
    {
        public static void RegisterDependencyModules(IServiceCollection services)
        {
            services.AddLogging(logging =>
            {
                logging.AddConsole(); 
            });
            services.AddTransient<LoggerRecordService>();
            //services.AddTransient<IRecordService, ConsoleRecordService>();
            services.AddTransient<IRecordService, LoggerRecordService>();
            services.AddKeyedTransient<IBackendTask, ThreadBackendTask>(ServiceKeys.TB);
            services.AddKeyedTransient<IBackendTask, ExpressionBackendTask>(ServiceKeys.EB);
            services.AddTransient<IAppService,AppService>();
        }
    }
}
