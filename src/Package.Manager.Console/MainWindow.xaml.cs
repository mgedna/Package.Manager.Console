using Package.Manager.Console.Application.Contracts;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace Package.Manager.Console;
public partial class MainWindow : Window
{
    private readonly IShellWrapper _shellService;
    public MainWindow(IShellWrapper shellService)
    {
        InitializeComponent();

        _shellService = shellService;
    }

    private void CommandInput_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
            RunCommand_Click(RunButton, new RoutedEventArgs());
    }

    private async void RunCommand_Click(object sender, RoutedEventArgs e)
    {
        string command = CommandInput.Text.Trim();

        if (string.IsNullOrWhiteSpace(command))
        {
            AddToOutput("Please enter a command.", Brushes.Gray);

            return;
        }

        CommandOutput.Document.Blocks.Clear();
        StatusBarText.Text = $"Running: {command}";

        var result = await _shellService.RunShellCommandAsync(command);

        foreach (var line in result.Output)
            AddToOutput(line, Brushes.LightGreen);

        foreach (var line in result.Error)
            AddToOutput(line, Brushes.IndianRed);

        AddToOutput($"[Exit Code: {result.ExitCode}]", Brushes.Gray);
        StatusBarText.Text = $"Finished with exit code: {result.ExitCode}";
    }

    private void AddToOutput(string text, Brush color)
    {
        var paragraph = new Paragraph(new Run(text)) { Margin = new Thickness(0), Foreground = color };

        CommandOutput.Document.Blocks.Add(paragraph);

        CommandOutput.ScrollToEnd();
    }

    private void ClearOutput_Click(object sender, RoutedEventArgs e)
    {
        ClearCommands();

        StatusBarText.Text = "Output cleared.";
    }

    private void CopyOutput_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            TextRange textRange = new(CommandOutput.Document.ContentStart, CommandOutput.Document.ContentEnd);

            Clipboard.SetText(textRange.Text);

            StatusBarText.Text = "Output copied to clipboard.";
        }
        catch (Exception ex)
        {
            ClearCommands();

            StatusBarText.Text = $"Error: {ex.Message}";
        }
    }

    private void ClearCommands()
    {
        CommandOutput.Document.Blocks.Clear();

        CommandInput.Clear();

        CommandInput.Focus();
    }
}