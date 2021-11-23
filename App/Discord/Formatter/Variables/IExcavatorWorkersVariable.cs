using NiceHashQuickMinerRichPresence.Excavator;

namespace NiceHashQuickMinerRichPresence.Discord.Formatter.Variables;

public interface IExcavatorWorkersVariable : IFormatVariable
{
    public string GetText(ExcavatorWorkersResponse workers);
}
