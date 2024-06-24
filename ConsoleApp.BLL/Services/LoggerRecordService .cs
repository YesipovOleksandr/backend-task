using ConsoleApp.Common.Abstract;
using Microsoft.Extensions.Logging;

namespace ConsoleApp.BLL.Services
{
    public class LoggerRecordService : IRecordService
    {
        private readonly ILogger<LoggerRecordService> _logger;

        public LoggerRecordService(ILogger<LoggerRecordService> logger)
        {
            _logger = logger;
        }

        public void ProcessRecord(string text)
        {
            _logger.LogInformation(text);
        }
    }
}
