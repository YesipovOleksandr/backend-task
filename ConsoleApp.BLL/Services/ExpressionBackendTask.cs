using ConsoleApp.Common.Abstract;
using ConsoleApp.Models;

namespace ConsoleApp.BLL.Services;

public class ExpressionBackendTask : IBackendTask
{
    private readonly IRecordService _recordServices;
    public ExpressionBackendTask(IRecordService recordServices)
    {
        _recordServices = recordServices;
    }
    public async Task RunAsync()
    {
        var fields = new[] { nameof(Product.Id), nameof(Product.Name) };
        var products = await LoadRecords<Product>(fields);
        WriteRecords(products, fields);
    }

    protected virtual async Task<IQueryable<T>> LoadRecords<T>(params string[] fields) where T : IPrimaryEntity
    {
        var records = LoadRecords<T>();
        await Task.Delay(100 * (fields.Length + 1));
        return records;
    }

    protected virtual void WriteRecord<T>(T record, params string[] fields) where T : IPrimaryEntity
    {
        _recordServices.ProcessRecord($"Record {record.Id}:");
        var fieldMessages = fields.Select(field => $"{field} = record[field]");
        _recordServices.ProcessRecord(string.Join("; ", fieldMessages));
    }

    private void WriteRecords<T>(IEnumerable<T> records, string[] fields) where T : IPrimaryEntity
    {
        foreach (var record in records)
        {
            WriteRecord(record, fields);
        }
    }

    private IQueryable<T> LoadRecords<T>() where T : IPrimaryEntity
    {
        return new[] {
      new Product(1, "product 1", "description 1", 50.5m),
      new Product(2, "product 2", "description 2", 25.3m),
      new Product(3, "product 3", "description 3", 165.1m),
    }.Cast<T>().AsQueryable();
    }
}
