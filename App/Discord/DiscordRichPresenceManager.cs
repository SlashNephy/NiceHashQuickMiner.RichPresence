using DiscordRPC;
using NiceHashQuickMinerRichPresence.Configuration;

namespace NiceHashQuickMinerRichPresence.Discord;

public sealed class DiscordRichPresenceManager : IDiscordRichPresenceManager
{
    private readonly IConfigManager configManager;
    private DiscordRpcClient? client;

    public DiscordRichPresenceManager(IConfigManager configManager)
    {
        this.configManager = configManager;
    }

    private bool InitializeRpcClient()
    {
        if (client?.IsDisposed == false)
        {
            return true;
        }

        client = new(configManager.Config.DiscordApplicationId)
        {
            SkipIdenticalPresence = true
        };
        client.OnConnectionFailed += (_, _) =>
        {
            client?.Dispose();
        };

        return client.Initialize();
    }

    public void Update(RichPresence presence)
    {
        if (!InitializeRpcClient())
        {
            return;
        }

        client?.SetPresence(presence);
        if (client?.AutoEvents == false)
        {
            client?.Invoke();
        }
    }

    public void Dispose()
    {
        client?.Dispose();
    }
}
