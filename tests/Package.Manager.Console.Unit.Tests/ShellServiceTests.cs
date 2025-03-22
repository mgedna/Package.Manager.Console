using Moq;
using Package.Manager.Console.Application.Contracts;
using Package.Manager.Console.Application.Implementations;
using Package.Manager.Console.Domain.Records;
using Shouldly;

namespace Package.Manager.Console.Unit.Tests;

public class ShellServiceTests
{
    private readonly ShellService _sut;
    private readonly Mock<IShellWrapper> _shellWrapper;

    public ShellServiceTests()
    {
        _shellWrapper = new Mock<IShellWrapper>();

        _sut = new ShellService(_shellWrapper.Object);
    }

    [Fact]
    public async Task ExecuteCommandAsync_ShouldReturn_Success()
    {
        // Arrange
        var reqShell = "echo test";

        ShellResponse responseFromShell = new()
        {
            ExitCode = 0,
            Output = ["test"],
            Error = []
        };

        _shellWrapper.Setup(shell => shell.RunShellCommandAsync(It.IsAny<string>())).ReturnsAsync(responseFromShell);

        // Act
        var result = await _sut.ExecuteCommandAsync(reqShell);

        // Assert
        result.ShouldNotBeNull();
        result.ShouldBeEquivalentTo(responseFromShell);
    }


    [Fact]
    public async Task ExecuteCommandAsync_ShouldReturn_IncorrectResult()
    {
        // Arrange
        var reqShell = "echo fail";

        var expectedResponse = new ShellResponse
        {
            ExitCode = 0,
            Output = ["not what I expected"],
            Error = []
        };

        _shellWrapper.Setup(shell => shell.RunShellCommandAsync(It.IsAny<string>())).ReturnsAsync(expectedResponse);

        // Act
        var result = await _sut.ExecuteCommandAsync(reqShell);

        // Assert
        result.ShouldNotBeNull();
        result.ShouldNotBe(new ShellResponse
        {
            ExitCode = 0,
            Output = ["something else"],
            Error = []
        });
    }

    [Fact]
    public async Task ExecuteCommandAsync_ShouldReturn_ErrorResponse_WhenExceptionOccurs()
    {
        var reqShell = "badcommand";

        _shellWrapper.Setup(shell => shell.RunShellCommandAsync(It.IsAny<string>())).ThrowsAsync(new Exception("Something went wrong with your shell"));

        var result = await _sut.ExecuteCommandAsync(reqShell);

        result.ShouldNotBeNull();
        result.ExitCode.ShouldBe(-1);
        result.Error.ShouldContain("Something went wrong with your shell");
    }
}