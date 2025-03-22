using Package.Manager.Console.Domain.Records;

namespace Package.Manager.Console.Application.Contracts;

public interface IShellService
{
    Task<ShellResponse> ExecuteCommandAsync(string command);
}
