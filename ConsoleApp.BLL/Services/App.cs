using ConsoleApp.Common.Abstract;

namespace ConsoleApp.BLL.Services
{
    public class App : IApp
    {
        private readonly IBackendTask _task1;
        private readonly IBackendTask _task2;

        public App(IBackendTask task1, IBackendTask task2)
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
