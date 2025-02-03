using Domain.OperationCategory.Service;
using ItDevRisk.Actions;
using ItDevRisk.DomainInjection;
using ItDevRisk.Helpers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Globalization;

IHost host = Host.CreateDefaultBuilder(args)


    .ConfigureServices((h, services) =>
    {
        services.AddInfraestructure(h.Configuration);
        services.AddTransient<MainActions>();
    })
    .Build();

using (var scope = host.Services.CreateScope())
{
    var mainAction = scope.ServiceProvider.GetRequiredService<MainActions>();
    await mainAction.ExecuteAsync();
}

var my = host.RunAsync();
//await host.RunAsync();