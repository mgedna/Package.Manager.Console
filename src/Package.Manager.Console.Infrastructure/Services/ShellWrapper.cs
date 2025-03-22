using Package.Manager.Console.Application.Contracts;
using Package.Manager.Console.Domain.Records;
using System.Diagnostics;

namespace Package.Manager.Console.Infrastructure.Services;

public class ShellWrapper : IShellWrapper
{
    public async Task<ShellResponse> RunShellCommandAsync(string command)
    {
        ShellResponse result = new();

        var psi = new ProcessStartInfo
        {
            FileName = "cmd.exe",
            Arguments = $"/c {command}",
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        var process = new Process { StartInfo = psi };

        process.OutputDataReceived += (s, e) =>
        {
            if (!string.IsNullOrWhiteSpace(e.Data))
                result.Output.Add(e.Data);
        };

        process.ErrorDataReceived += (s, e) =>
        {
            if (!string.IsNullOrWhiteSpace(e.Data))
                result.Error.Add(e.Data);
        };

        process.Start();
        process.BeginOutputReadLine();
        process.BeginErrorReadLine();

        await Task.Run(() => process.WaitForExit());

        result.ExitCode = process.ExitCode;

        return result;
    }
}
