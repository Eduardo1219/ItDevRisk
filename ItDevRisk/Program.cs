// See https://aka.ms/new-console-template for more information

using ItDevRisk.DomainInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

IHost host = Host.CreateDefaultBuilder(args)


    .ConfigureServices((h, services) =>
    {
        services.AddInfraestructure(h.Configuration);
        services.AddTransient<MyService>();
    })
    .Build();

// var my = host.Services.GetRequiredService<MyService>();
// await my.ExecuteAsync();
await host.RunAsync();

class MyService
{
    private readonly ILogger<MyService> _logger;

    public MyService(ILogger<MyService> logger)
    {
        _logger = logger;
    }

    public async Task ExecuteAsync(CancellationToken stoppingToken = default)
    {
        _logger.LogInformation("Doing something");
    }
}