using NiceHashQuickMinerRichPresence.Configuration;
using NiceHashQuickMinerRichPresence.Discord;
using NiceHashQuickMinerRichPresence.Discord.Formatter;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NiceHashQuickMinerRichPresence.Tasks;

public sealed class RichPresenceBackgroundTask : IBackgroundTask
{
    private readonly IConfigManager configManager;
    private readonly IDiscordRichPresenceManager richPresenceManager;
    private readonly IRichPresenceFormatter richPresenceFormatter;

    public RichPresenceBackgroundTask(IConfigManager configManager, IDiscordRichPresenceManager richPresenceManager, IRichPresenceFormatter richPresenceFormatter)
    {
        this.configManager = configManager;
        this.richPresenceManager = richPresenceManager;
        this.richPresenceFormatter = richPresenceFormatter;
    }

    public async Task Run(CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            var presence = richPresenceFormatter.Format();
            richPresenceManager.Update(presence);

            await Task.Delay(Convert.ToInt32(configManager.Config.UpdateIntervalMs), token);
        }
    }
}
