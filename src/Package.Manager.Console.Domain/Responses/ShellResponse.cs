namespace Package.Manager.Console.Domain.Records;

public class ShellResponse
{
    public int ExitCode { get; set; } = default;
    public List<string> Output { get; set; } = [];
    public List<string> Error { get; set; } = [];
}