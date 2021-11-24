using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using NiceHashQuickMinerRichPresence.Configuration;
using NiceHashQuickMinerRichPresence.Discord;
using NiceHashQuickMinerRichPresence.Discord.Formatter;
using NiceHashQuickMinerRichPresence.Excavator;
using NiceHashQuickMinerRichPresence.Tasks;
using System;
using System.Diagnostics;
using WinUIEx;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace NiceHashQuickMinerRichPresence;

/// <summary>
/// Provides application-specific behavior to supplement the default Application class.
/// </summary>
public partial class App : Application
{
    private IServiceProvider ServiceProvider { get; }

    /// <summary>
    /// Initializes the singleton application object.  This is the first line of authored code
    /// executed, and as such is the logical equivalent of main() or WinMain().
    /// </summary>
    public App()
    {
#if DEBUG
        UnhandledException += OnUnhandledException;
#endif

        var collection = new ServiceCollection();
        RegisterServices(collection);
        ServiceProvider = collection.BuildServiceProvider();

        InitializeComponent();
    }

#if DEBUG
    private void OnUnhandledException(object sender, Microsoft.UI.Xaml.UnhandledExceptionEventArgs e)
    {
        Debug.WriteLine(e.Exception);
        Debug.WriteLine(e.Exception.StackTrace);
    }
#endif

    private static void RegisterServices(IServiceCollection collection)
    {
        collection.AddSingleton<IConfigManager, ConfigManager>();
        collection.AddSingleton<IExcavatorApiClient, ExcavatorApiClient>();
        collection.AddSingleton<IDataFetchingBackgroundTask, DataFetchingBackgroundTask>();
        collection.AddSingleton<IDiscordRichPresenceManager, DiscordRichPresenceManager>();
        collection.AddSingleton<RichPresenceBackgroundTask>();
        collection.AddSingleton<IRichPresenceFormatter, RichPresenceFormatter>();
        collection.AddSingleton<IBackgroundTaskRunner, BackgroundTaskRunner>();
        collection.AddSingleton<MainWindow>();
    }

    /// <summary>
    /// Invoked when the application is launched normally by the end user.  Other entry points
    /// will be used such as when the application is launched to open a specific file.
    /// </summary>
    /// <param name="args">Details about the launch request and process.</param>
    protected override void OnLaunched(LaunchActivatedEventArgs args)
    {
        ServiceProvider.GetRequiredService<IBackgroundTaskRunner>().Run();
        ServiceProvider.GetRequiredService<MainWindow>().MinimizeWindow();
    }
}
