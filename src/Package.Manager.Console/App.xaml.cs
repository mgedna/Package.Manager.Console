using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Package.Manager.Console.Application;
using Package.Manager.Console.Infrastructure;
using System.Windows;

namespace Package.Manager.Console;
public partial class App : System.Windows.Application
{
    private IHost? _host;

    protected override void OnStartup(StartupEventArgs e)
    {
        _host = Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                ApplicationDependencies.Register(services);
                InfrastructureDependencies.Register(services);
                services.AddSingleton<MainWindow>();
            })
            .Build();

        _host.Start();

        _host.Services.GetRequiredService<MainWindow>().Show();

        base.OnStartup(e);
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        if (_host != null)
        {
            await _host.StopAsync();
            _host.Dispose();
        }

        base.OnExit(e);
    }
}
