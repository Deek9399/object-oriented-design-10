using MauiApp1.Services;

namespace MauiApp1;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        // Initialize the database when the app starts
        InitDatabaseAsync().ConfigureAwait(false); // Avoid blocking the UI thread
    }

    private async Task InitDatabaseAsync()
    {
        // Call the database initialization method
        await DatabaseService.InitAsync();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(new AppShell());
    }
}