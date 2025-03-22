using Package.Manager.Console.Application.Contracts;
using Package.Manager.Console.Domain.Records;

namespace Package.Manager.Console.Application.Implementations;

public class ShellService(IShellWrapper _shellWrapper) : IShellService
{
    public async Task<ShellResponse> ExecuteCommandAsync(string command)
    {
        try
        {
            return await _shellWrapper.RunShellCommandAsync(command);
        }
        catch (Exception ex)
        {
            return new()
            {
                ExitCode = -1,
                Error =
                [
                    ex.Message
                ]
            };
        }
    }
}
