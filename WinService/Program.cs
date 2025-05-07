using DisableEthernet;

IHost host = Host.CreateDefaultBuilder(args)
    .UseWindowsService() // Enables running as Windows Service
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();
