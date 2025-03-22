using Microsoft.Extensions.DependencyInjection;
using Package.Manager.Console.Application.Contracts;
using Package.Manager.Console.Application.Implementations;

namespace Package.Manager.Console.Application;

public static class ApplicationDependencies
{
    public static void Register(IServiceCollection services)
    => services.AddSingleton<IShellService, ShellService>();
}
