using ConsoleApp.Common.Abstract;

namespace ConsoleApp.BLL.Services
{
    public class LimitedExpressionBackendTask : ExpressionBackendTask
    {
        private readonly IRecordService _recordServices;
        public LimitedExpressionBackendTask(IRecordService recordServices) : base(recordServices)
        {
            _recordServices = recordServices;
        }

        protected override void WriteRecord<T>(T record, params string[] fields)
        {
            var objectType = record.GetType();
            var properties = objectType.GetProperties();

            var fieldMessages = fields
                .Where(field => properties.Any(p => string.Equals(p.Name, field, StringComparison.OrdinalIgnoreCase)))
                .Select(field =>
                {
                    var property = properties.First(p => string.Equals(p.Name, field, StringComparison.OrdinalIgnoreCase));
                    var value = property.GetValue(record);
                    return $"{field} = {value}";
                });

            foreach (var message in fieldMessages)
            {
                _recordServices.ProcessRecord(message);
            }
        }
    }
}