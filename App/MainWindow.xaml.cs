using Microsoft.UI.Xaml;
using NiceHashQuickMinerRichPresence.Configuration;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace NiceHashQuickMinerRichPresence;

/// <summary>
/// An empty window that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class MainWindow : Window
{
    private readonly IConfigManager configManager;
    // private TrayIcon? trayIcon;

    public MainWindow(IConfigManager configManager)
    {
        this.configManager = configManager;
        Title = "Discord Rich Presence for NHQM";

        InitializeComponent();
    }

    /*
    public void InitializeTrayIcon()
    {
        var icon = Icon.FromFile("Assets/icon.ico");
        trayIcon = new TrayIcon(icon);
        trayIcon.TrayIconLeftMouseDown += (s, e) =>
        {
            this.ShowWindow();
        };

        this.HideWindow();
    }
    */

    private void SaveConfigButton_Click(object sender, RoutedEventArgs e)
    {
        configManager.SaveAsync();
    }

    private void OpenConfigButton_Click(object sender, RoutedEventArgs e)
    {
        configManager.LaunchFileAsync();
    }
}
