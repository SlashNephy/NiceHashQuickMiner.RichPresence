using DiscordRPC;

namespace NiceHashQuickMinerRichPresence.Discord.Formatter;

public interface IRichPresenceFormatter
{
    public string FormatDetails();
    public string FormatState();
    public string FormatLargeImageText();
    public string FormatSmallImageText();
    public Timestamps GetElapsed();
    public RichPresence Format();
}
