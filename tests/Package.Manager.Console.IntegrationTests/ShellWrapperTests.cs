using Package.Manager.Console.Infrastructure.Services;
using Shouldly;

namespace Package.Manager.Console.IntegrationTests;

public class ShellServiceIntegrationTests
{
    private readonly ShellWrapper _service = new();

    [Fact]
    public async Task RunShellCommandAsync_ShouldReturn_Output_ForValidCommand()
    {
        var command = "echo Hello World";

        var result = await _service.RunShellCommandAsync(command);

        result.ShouldNotBeNull();
        result.ExitCode.ShouldBe(0);
        result.Output.ShouldContain("Hello World");
        result.Error.ShouldBeEmpty();
    }

    [Fact]
    public async Task RunShellCommandAsync_ShouldReturn_Error_ForInvalidCommand()
    {
        var command = "dottnet";

        var result = await _service.RunShellCommandAsync(command);

        result.ShouldNotBeNull();
        result.ExitCode.ShouldNotBe(0);
        result.Output.ShouldBeEmpty();
        result.Error.ShouldNotBeEmpty();
    }

    [Fact]
    public async Task RunShellCommandAsync_ShouldReturn_MultipleLines()
    {
        var command = "dotnet -h";

        var result = await _service.RunShellCommandAsync(command);

        result.ShouldNotBeNull();
        result.ExitCode.ShouldBe(0);
        result.Output.Count.ShouldBeGreaterThan(1);
        result.Error.ShouldBeEmpty();
    }
}
