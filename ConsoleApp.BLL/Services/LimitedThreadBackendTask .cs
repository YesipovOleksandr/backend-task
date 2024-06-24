using ConsoleApp.Common.Abstract;

namespace ConsoleApp.BLL.Services
{
    public class LimitedThreadBackendTask : ThreadBackendTask, IBackendTask
    {
        private readonly SemaphoreSlim _semaphore;

        public LimitedThreadBackendTask(IRecordService recordServices) : base(recordServices)
        {
            _semaphore = new SemaphoreSlim(5);
        }

        protected override async Task<IEnumerable<ThreadTaskItemResult>> ExecuteAsync(IEnumerable<ThreadTaskItemConfig> configs)
        {
            var tasks = configs.Select(config => ExecuteWithSemaphoreAsync(config));
            return await Task.WhenAll(tasks);
        }

        private async Task<ThreadTaskItemResult> ExecuteWithSemaphoreAsync(ThreadTaskItemConfig config)
        {
            await _semaphore.WaitAsync();
            try
            {
                return await base.ExecuteAsync(config);
            }
            finally
            {
                _semaphore.Release();
            }
        }
    }
}