using ConsoleApp.Common.Abstract;
using Microsoft.Extensions.DependencyInjection;
using ReportApi.Common;

namespace ConsoleApp.BLL.Services
{
    public class App : IApp
    {
        private readonly IBackendTask _task1;
        private readonly IBackendTask _task2;

        public App([FromKeyedServices(ServiceKeys.TB)] IBackendTask task1, [FromKeyedServices(ServiceKeys.EB)] IBackendTask task2)
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
