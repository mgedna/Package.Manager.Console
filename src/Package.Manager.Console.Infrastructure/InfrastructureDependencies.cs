using Microsoft.Extensions.DependencyInjection;
using Package.Manager.Console.Application.Contracts;
using Package.Manager.Console.Infrastructure.Services;

namespace Package.Manager.Console.Infrastructure;

public static class InfrastructureDependencies
{
    public static void Register(IServiceCollection services)
    => services.AddSingleton<IShellWrapper, ShellWrapper>();
}
