using DiscordRPC;
using System;

namespace NiceHashQuickMinerRichPresence.Discord;

public interface IDiscordRichPresenceManager : IDisposable
{
    public void Update(RichPresence presence);
}
