using ConsoleApp.Common.Abstract;
using Microsoft.Extensions.DependencyInjection;
using ReportApi.Common;

namespace ConsoleApp.BLL.Services
{
    public class AppService : IAppService
    {
        private readonly IBackendTask _task1;
        private readonly IBackendTask _task2;

        public AppService([FromKeyedServices(ServiceKeys.TB)] IBackendTask task1, [FromKeyedServices(ServiceKeys.EB)] IBackendTask task2)
        {
            _task1 = task1;
            _task2 = task2;
        }

        public async Task RunAsync()
        {
            await _task1.RunAsync();
            await _task2.RunAsync();
        }
    }
}
