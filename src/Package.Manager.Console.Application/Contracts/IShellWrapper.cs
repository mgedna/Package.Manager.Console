using Package.Manager.Console.Domain.Records;

namespace Package.Manager.Console.Application.Contracts;

public interface IShellWrapper
{
    Task<ShellResponse> RunShellCommandAsync(string command);
}
