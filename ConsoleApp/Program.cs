using ConsoleApp.Common.Abstract;
using ConsoleApp.Dependencies;
using Microsoft.Extensions.DependencyInjection;

var serviceCollection = new ServiceCollection();
DependencyRegistrator.RegisterDependencyModules(serviceCollection);

var serviceProvider = serviceCollection.BuildServiceProvider();

var app = serviceProvider.GetRequiredService<IAppService>();
await app.RunAsync();

