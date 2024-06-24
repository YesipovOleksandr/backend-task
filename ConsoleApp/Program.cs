using ConsoleApp.Tasks;
using Microsoft.Extensions.DependencyInjection;

var serviceCollection = new ServiceCollection();
ConfigureServices(serviceCollection);

var serviceProvider = serviceCollection.BuildServiceProvider();

var app = serviceProvider.GetRequiredService<App>();
await app.RunAsync();


static void ConfigureServices(IServiceCollection services)
{
    services.AddTransient<IBackendTask,ThreadBackendTask>();
    services.AddTransient<IBackendTask,ExpressionBackendTask>();
    services.AddTransient<App>();
}

public class App
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